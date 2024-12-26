using System.Runtime.CompilerServices;
using Ahatornn.TestGenerator;
using FluentAssertions;
using InvoiceSystem.Common;
using InvoiceSystem.Database;
using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Xunit;

namespace InvoiceSystem.Repositories.Tests
{
    /// <summary>
    /// Тесты наследников <see cref="BaseReadRepository{T}"/>
    /// </summary>
    [Collection(nameof(DBTestsCollection))]
    public abstract class BaseReadRepositoryTests<TObject>
        where TObject : DBObject, new()
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        readonly protected InvcSysDBContext dBContext;
        /// <summary>
        /// Дата и время
        /// </summary>
        readonly protected IDateTimeOffsetProvider dateTime;

        private readonly CancellationToken cancellationToken;
        private readonly IReadRepository<TObject> repository;
        private readonly DbSet<TObject> dbSet;

        /// <summary>
        /// Конструктор
        /// </summary>
        public BaseReadRepositoryTests(DBTestsFixture fixture)
        {
            dBContext = fixture.DbContext;
            cancellationToken = fixture.CancellationToken;
            dateTime = fixture.DateTimeMock;
            repository = Repository();
            dbSet = DBSet();
            ClearDbSet();
        }

        #region abstract 

        /// <summary>
        /// Конструктор DBObject
        /// </summary>
        protected abstract TObject NewDBObject();

        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        protected abstract IReadRepository<TObject> Repository();

        /// <summary>
        /// Выдаёт нужную таблицу БД
        /// </summary>
        protected abstract DbSet<TObject> DBSet();

        #endregion

        /// <summary>
        /// Получение всех ничего не возвращает
        /// </summary>
        [Fact]
        public async Task GetAllReturnsEmpty()
        {
            // Act
            var result = await repository.GetAll(cancellationToken);

            // Assert
            result.Should().BeEmpty();
        }

        /// <summary>
        /// Получение всех выдаёт 1 элемент, хотя там 2, ведь один из них удалён
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnUndeleted()
        {
            // Arrange
            var obj0 = NewDBObject();
            var obj1 = NewDBObject();
            obj1.DeletedDate = dateTime.UtcNow;

            dbSet.AddRange(obj0, obj1);
            dBContext.SaveChanges();

            // Act
            var result = await repository.GetAll(cancellationToken);

            // Assert
            result.Should()
                .NotBeEmpty()
                .And.HaveCount(1)
                .And.ContainSingle(x => x.Id == obj0.Id);
        }

        /// <summary>
        /// Получение по ID ничего не возвращает
        /// </summary>
        [Fact]
        public async Task GetByIdReturnsNull()
        {
            // Act
            var result = await repository.GetById(Guid.NewGuid(), cancellationToken);

            // Assert
            result.Should().BeNull();
        }

        /// <summary>
        /// Получение по ID не выдаёт удаленный элемент
        /// </summary>
        [Fact]
        public async Task GetByIdDoesntReturnDeleted()
        {
            // Arrange
            var obj = NewDBObject();
            obj.DeletedDate = dateTime.Now;
            dbSet.AddRange(obj);
            dBContext.SaveChanges();

            // Act
            var result = await repository.GetById(obj.Id, cancellationToken);

            // Assert
            result.Should().BeNull();
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
            var result = await repository.GetById(obj.Id, cancellationToken);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(obj);
        }

        private void ClearDbSet()
        {
            dbSet.RemoveRange(dbSet);
            dBContext.SaveChanges();
        }
    }
}
