using AutoMapper;
using FluentAssertions;
using InvoiceSystem.Common;
using InvoiceSystem.Database;
using InvoiceSystem.Database.Contracts.ModelInterfaces;
using InvoiceSystem.Models;
using InvoiceSystem.Services.Contracts;
using InvoiceSystem.Services.Models.Customers;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InvoiceSystem.Services.Tests
{
    /// <summary>
    /// Тесты <see cref="CustomerService"/>
    /// </summary>
    [Collection(nameof(DBTestsCollection))]
    public abstract class BaseServiceTests<TAddObjectModel, TObjectModel, TObject, TObjectService>
        where TObject : DBObject, new()
        where TObjectModel : IUniqueID, TAddObjectModel
        where TAddObjectModel : class, new()
        where TObjectService : IDBobjectService<TAddObjectModel, TObjectModel, TObject>
    {
        private readonly InvcSysDBContext dBContext;
        private readonly CancellationToken cancellationToken;
        private readonly IDateTimeOffsetProvider dateTime;
        private readonly TObjectService service;

        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        protected abstract TObjectService Service();

        /// <summary>
        /// Конструктор
        /// </summary>
        public BaseServiceTests(DBTestsFixture fixture)
        {
            dBContext = fixture.DbContext;
            cancellationToken = fixture.CancellationToken;
            dateTime = fixture.DateTimeMock;

            var mapper = new Mapper(
                new MapperConfiguration(x =>
                {
                    x.CreateMap<TObject, TObjectModel>(MemberList.Destination);
                    x.CreateMap<TAddObjectModel, TObject>(MemberList.Destination);
                }));

            service = Service();
        }

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
            dBContext.Set<TObject>().AddRange(
                NewTObject(),
                NewTObject(),
                NewTObject()
                );

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
        public async Task GetByIdShouldReturnNull()
        {
            // Arrange
            dBContext.Set<TObject>().AddRange(NewTObject(), NewTObject());

            // Act
            var result = await service.GetById(Guid.NewGuid(), cancellationToken);

            // Assert
            result.Should()
                .BeNull();
        }

        /// <summary>
        /// Получение по ID находит
        /// </summary>
        [Fact]
        public async Task GetByIdShouldWork()
        {
            // Arrange
            var model = NewTObject();
            dBContext.Set<TObject>().AddRange(model, NewTObject());

            // Act
            var result = await service.GetById(model.Id, cancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(model);
        }

        /// <summary>
        /// Удаление работает
        /// </summary>
        [Fact]
        public async Task DeleteShouldWork()
        {
            // Arrange
            var model = NewTObject();
            dBContext.Set<TObject>().AddRange(model, NewTObject());

            // Act
            await service.Delete(model.Id, cancellationToken);
            var result = await service.GetAll(cancellationToken);

            // Assert
            result.Should()
                 .NotBeEmpty()
                 .And.HaveCount(2);
        }

        /// <summary>
        /// Добавление работает
        /// </summary>
        [Fact]
        public async Task AddShouldWork()
        {
            // Arrange
            var model = new TAddObjectModel();

            // Act
            var result = await service.Add(model, cancellationToken);

            // Assert
            result.Should().NotBe(Guid.Empty);
            var item = await dBContext.Set<TObject>()
                .FirstOrDefaultAsync(x => x.Id == result, cancellationToken);
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
        }

        private TObject NewTObject()
        {
            return new TObject() { Id = new Guid(), CreatedDate = dateTime.UtcNow };
        }
    }
}
