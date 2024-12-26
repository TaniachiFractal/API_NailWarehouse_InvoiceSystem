using AutoMapper;
using FluentAssertions;
using InvoiceSystem.Common;
using InvoiceSystem.Database;
using InvoiceSystem.Database.Contracts.ModelInterfaces;
using InvoiceSystem.Exceptions;
using InvoiceSystem.Models;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InvoiceSystem.Services.Tests
{
    /// <summary>
    /// Тесты наследников <see cref="DBObjectService{TAddObjectModel, TObjectModel, TObject}"/>
    /// </summary>
    [Collection(nameof(DBTestsCollection))]
    public abstract class DBObjectServiceBaseTests<TAddObjectModel, TObjectModel, TObject, TObjectService>
        where TObject : DBObject, new()
        where TObjectModel : IUniqueID, TAddObjectModel
        where TAddObjectModel : class, new()
        where TObjectService : DBObjectService<TAddObjectModel, TObjectModel, TObject>
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

        private readonly CancellationToken cancellationToken;
        private readonly TObjectService service;
        private readonly DbSet<TObject> dbSet;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DBObjectServiceBaseTests(DBTestsFixture fixture)
        {
            dBContext = fixture.DbContext;
            cancellationToken = fixture.CancellationToken;
            dateTime = fixture.DateTimeMock;

            mapper = new Mapper(
                new MapperConfiguration(x =>
                {
                    x.CreateMap<TObject, TObjectModel>(MemberList.Destination);
                    x.CreateMap<TAddObjectModel, TObject>(MemberList.Destination);
                }));

            service = Service();
            dbSet = DBSet();
            ClearDbSet();
        }

        #region abstract constructors

        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        protected abstract TObjectService Service();

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
        /// Получение всех ничего не выдаёт
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnEmpty()
        {
            // Act
            var result = await service.GetAll(cancellationToken);

            // Assert
            result.Should()
                .BeEmpty();
        }

        /// <summary>
        /// Получение всех выдаёт 3 элемента
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturn3Items()
        {
            // Arrange
            await service.Add(NewAddObjectModel(), cancellationToken);
            await service.Add(NewAddObjectModel(), cancellationToken);
            await service.Add(NewAddObjectModel(), cancellationToken);

            // Act
            var result = await service.GetAll(cancellationToken);

            // Assert
            result.Should()
                .NotBeEmpty()
                .And.HaveCount(3);
        }

        /// <summary>
        /// Получение по ID не находит
        /// </summary>
        [Fact]
        public async Task GetByIdShouldThrow()
        {
            // Act
            try
            {
                await service.GetById(Guid.NewGuid(), cancellationToken);
            }
            // Assert
            catch (Exception ex)
            {
                Assert.True(ex.GetType() == typeof(NotFoundException));
            }
        }

        /// <summary>
        /// Получение по ID находит
        /// </summary>
        [Fact]
        public async Task GetByIdShouldWork()
        {
            // Arrange
            var model = NewAddObjectModel();
            var modelId = await service.Add(model, cancellationToken);
            await service.Add(NewAddObjectModel(), cancellationToken);

            // Act
            var result = await service.GetById(modelId, cancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(model);
        }

        #endregion

        #region write

        /// <summary>
        /// Удаление работает
        /// </summary>
        [Fact]
        public async Task DeleteShouldWork()
        {
            // Arrange
            var model = NewAddObjectModel();
            var modelId = await service.Add(model, cancellationToken);
            await service.Add(NewAddObjectModel(), cancellationToken);

            // Act
            await service.Delete(modelId, cancellationToken);
            var result = await service.GetAll(cancellationToken);

            // Assert
            result.Should()
                .NotBeEmpty()
                .And.HaveCount(1);
        }

        /// <summary>
        /// Добавление работает
        /// </summary>
        [Fact]
        public async Task AddShouldWork()
        {
            // Arrange
            var model = NewAddObjectModel();

            // Act
            var result = await service.Add(model, cancellationToken);

            // Assert
            result.Should().NotBe(Guid.Empty);
            var item = await dbSet.FirstOrDefaultAsync(x => x.Id == result, cancellationToken);
            item.Should()
                .NotBeNull()
                .And.BeEquivalentTo(model);
        }

        /// <summary>
        /// Изменение работает
        /// </summary>
        [Fact]
        public async Task EditShouldWork()
        {
            // Arrange
            var entity = NewAddObjectModel();
            var entityId = await service.Add(entity, cancellationToken);

            var model = NewObjectModel();
            model.Id = entityId;

            // Act
            await service.Edit(model, cancellationToken);

            // Assert
            var item = await dbSet.FirstOrDefaultAsync(x => x.Id == entityId, cancellationToken);
            item.Should()
                .NotBeNull()
                .And.BeEquivalentTo(model)
                .And.NotBeEquivalentTo(entity);
        }

        #endregion

        private void ClearDbSet()
        {
            dbSet.RemoveRange(dbSet);
            dBContext.SaveChanges();
        }
    }
}
