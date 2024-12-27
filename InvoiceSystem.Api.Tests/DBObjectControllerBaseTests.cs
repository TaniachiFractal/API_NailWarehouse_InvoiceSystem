using AutoMapper;
using FluentAssertions;
using InvoiceSystem.Common;
using InvoiceSystem.Database;
using InvoiceSystem.Database.Contracts.ModelInterfaces;
using InvoiceSystem.Exceptions;
using InvoiceSystem.Models;
using InvoiceSystem.Services.Contracts;
using InvoiceSystem.TestsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Xunit;

namespace InvoiceSystem.Api.Tests
{
    /// <summary>
    /// Тесты наследников <see cref="DBObjectController{TAddApiModel, TApiModel, TAddObjectModel, TObjectModel, TObject}"/>
    /// </summary>
    [Collection(nameof(DBTestsCollection))]
    public abstract class DBObjectControllerBaseTests<TAddApiModel, TApiModel, TAddObjectModel, TObjectModel, TObject> : ControllerBase
        where TApiModel : TAddApiModel, IUniqueID
        where TObject : DBObject
        where TObjectModel : IUniqueID, TAddObjectModel
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        readonly protected InvcSysDBContext dBContext;
        /// <summary>
        /// Дата и время
        /// </summary>
        readonly protected IDateTimeOffsetProvider dateTime;
        /// <summary>
        /// Маппер
        /// </summary>
        readonly protected IMapper mapper;
        /// <summary>
        /// Логгер
        /// </summary>
        readonly protected ILogger logger;
        /// <summary>
        /// Сервис
        /// </summary>
        readonly protected IDBobjectService<TAddObjectModel, TObjectModel, TObject> service;
        /// <summary>
        /// Сервис валидации
        /// </summary>
        readonly protected IDBObjectValidationService validationService;
        /// <summary>
        /// Токен отмены
        /// </summary>
        readonly protected CancellationToken cancellationToken;

        private readonly DbSet<TObject> dbSet;
        private readonly DBObjectController<TAddApiModel, TApiModel, TAddObjectModel, TObjectModel, TObject> controller;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DBObjectControllerBaseTests(DBTestsFixture fixture)
        {
            dBContext = fixture.DbContext;
            cancellationToken = fixture.CancellationToken;
            dateTime = fixture.DateTimeMock;
            logger = fixture.Logger;

            mapper = new Mapper(
                new MapperConfiguration(x =>
                {
                    x.CreateMap<TObject, TObjectModel>(MemberList.Destination);
                    x.CreateMap<TAddObjectModel, TObject>(MemberList.Destination);

                    x.CreateMap<TObjectModel, TApiModel>(MemberList.Destination);
                    x.CreateMap<TAddApiModel, TAddObjectModel>(MemberList.Destination);

                    x.CreateMap<TAddApiModel, TObjectModel>(MemberList.Destination);

                }));

            dbSet = DBSet();
            service = Service();
            validationService = ValidationService();
            controller = Controller();
            ClearDbSet();
        }

        #region abstract

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        protected abstract DBObjectController<TAddApiModel, TApiModel, TAddObjectModel, TObjectModel, TObject> Controller();

        /// <summary>
        /// Конструктор AddApiModel с правильными полями
        /// </summary>
        protected abstract TAddApiModel CorrectFields();

        /// <summary>
        /// Конструктор AddApiModel с неправильными полями
        /// </summary>
        protected abstract TAddApiModel WrongFields();

        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        protected abstract IDBobjectService<TAddObjectModel, TObjectModel, TObject> Service();

        /// <summary>
        /// Конструктор сервиса валидации
        /// </summary>
        protected abstract IDBObjectValidationService ValidationService();

        /// <summary>
        /// Конструктор AddObjectModel
        /// </summary>
        protected abstract TAddObjectModel NewAddObjectModel();

        /// <summary>
        /// Конструктор ObjectModel
        /// </summary>
        protected abstract TObjectModel NewObjectModel();

        /// <summary>
        /// Конструктор DBObject
        /// </summary>
        protected abstract TObject NewDBObject();

        /// <summary>
        /// Выдаёт нужную таблицу БД
        /// </summary>
        protected abstract DbSet<TObject> DBSet();

        #endregion

        #region read

        /// <summary>
        /// Получение всех ничего не возвращает
        /// </summary>
        [Fact]
        public async Task GetAllReturnsEmpty()
        {
            // Act
            var result = await controller.GetAll(cancellationToken);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IReadOnlyCollection<TApiModel>>(okResult.Value);
            returnValue.Should().BeEmpty();
        }

        /// <summary>
        /// Получение всех не выдаёт удалённые объекты
        /// </summary>
        [Fact]
        public async Task GetAllReturnsUndeleted()
        {
            // Arrange
            var deleted = NewDBObject();
            deleted.DeletedDate = DateTime.Now;
            var obj = NewDBObject();
            dbSet.AddRange(deleted, obj);
            dBContext.SaveChanges();

            // Act
            var result = await controller.GetAll(cancellationToken);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IReadOnlyCollection<TApiModel>>(okResult.Value);
            returnValue.Should()
                .NotBeEmpty()
                .And.HaveCount(1)
                .And.ContainSingle(x => x.Id == obj.Id);
        }

        /// <summary>
        /// Получение по ID выдаёт ошибку не найдено
        /// </summary>
        [Fact]
        public async Task GetByIdThrowsNotFound()
        {
            // Arrange
            var deleted = NewDBObject();
            deleted.DeletedDate = dateTime.UtcNow;
            dbSet.AddRange(deleted);
            dBContext.SaveChanges();

            // Act
            try
            {
                await controller.GetById(deleted.Id, cancellationToken);
            }
            // Assert
            catch (Exception ex)
            {
                Assert.True(ex.GetType() == typeof(NotFoundException));
            }
        }

        /// <summary>
        /// Получение по ID работает
        /// </summary>
        [Fact]
        public async Task GetByIdWorks()
        {
            // Arrange
            var obj = NewDBObject();
            dbSet.AddRange(obj);
            dBContext.SaveChanges();

            // Act
            var result = await controller.GetById(obj.Id, cancellationToken);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<TApiModel>(okResult.Value);
            returnValue.Should().BeEquivalentTo(obj, opt => opt.Excluding(x => x.CreatedDate).Excluding(x => x.UpdatedDate).Excluding(x => x.DeletedDate));
        }

        #endregion

        #region write

        /// <summary>
        /// Добавление выдаёт ошибку - неверные поля
        /// </summary>
        [Fact]
        public async Task AddThrowsWrongFields()
        {
            // Arrange
            var obj = WrongFields();

            // Act
            try
            {
                await controller.Add(obj, cancellationToken);
            }
            // Assert
            catch (Exception ex)
            {
                Assert.True(ex.GetType() == typeof(ValidationErrorException));
            }
        }

        /// <summary>
        /// Добавление работает
        /// </summary>
        [Fact]
        public async Task AddWorks()
        {
            // Arrange
            var oldCount = dbSet.Count();
            var obj = CorrectFields();

            // Act
            var result = await controller.Add(obj, cancellationToken);

            // Assert
            Assert.IsType<NoContentResult>(result);
            Assert.True(dbSet.Count() == oldCount + 1);
        }

        /// <summary>
        /// Изменение выдаёт ошибку - неверные поля
        /// </summary>
        [Fact]
        public async Task EditThrowsWrongFields()
        {
            // Arrange
            var obj = NewDBObject();
            dbSet.Add(obj);
            dBContext.SaveChanges();

            var model = WrongFields();

            // Act
            try
            {
                await controller.Edit(obj.Id, model, cancellationToken);
            }
            catch (Exception ex)
            {
                Assert.True(ex.GetType() == typeof(ValidationErrorException));
            }
        }

        /// <summary>
        /// Изменение выдаёт ошибку - объект не найден
        /// </summary>
        [Fact]
        public async Task EditThrowsNotFound()
        {
            // Arrange
            var obj = NewDBObject();
            obj.DeletedDate = dateTime.UtcNow;
            dbSet.Add(obj);
            dBContext.SaveChanges();

            var model = CorrectFields();

            // Act
            try
            {
                await controller.Edit(obj.Id, model, cancellationToken);
            }
            // Assert
            catch (Exception ex)
            {
                Assert.True(ex.GetType() == typeof(NotFoundException));
            }
        }

        /// <summary>
        /// Изменение работает
        /// </summary>
        [Fact]
        public async Task EditWorks()
        {
            // Arrange
            var obj = NewAddObjectModel();
            var objId = await service.Add(obj, cancellationToken);
            dBContext.SaveChanges();

            var model = CorrectFields();

            // Act
            var result = await controller.Edit(objId, model, cancellationToken);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        /// <summary>
        /// Удаление выдаёт ошибку - объект не найден
        /// </summary>
        [Fact]
        public async Task DeleteThrowsNotFound()
        {
            // Arrange
            var obj = NewDBObject();
            obj.DeletedDate = dateTime.UtcNow;
            dbSet.Add(obj);
            dBContext.SaveChanges();

            // Act
            try
            {
                await controller.Delete(obj.Id, cancellationToken);
            }
            // Assert
            catch (Exception ex)
            {
                Assert.True(ex.GetType() == typeof(NotFoundException));
            }
        }

        /// <summary>
        /// Удаление работает
        /// </summary>
        [Fact]
        public async Task DeleteWorks()
        {
            // Arrange
            var obj = NewAddObjectModel();
            var objId = await service.Add(obj, cancellationToken);
            dBContext.SaveChanges();

            // Act
            var result = await controller.Delete(objId, cancellationToken);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        #endregion

        private void ClearDbSet()
        {
            dbSet.RemoveRange(dbSet);
            dBContext.SaveChanges();
        }
    }
}
