using System.Runtime.CompilerServices;
using FluentAssertions;
using InvoiceSystem.Common;
using InvoiceSystem.Database;
using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InvoiceSystem.Repositories.Tests
{
    /// <summary>
    /// Тесты наследников <see cref="BaseWriteRepository{T}"/>
    /// </summary>
    [Collection(nameof(DBTestsCollection))]
    public abstract class BaseWriteRepositoryTests<TObject>
        where TObject : DBObject, new()
    {
        private const string NotFoundErrorMessage = "Entity not found";

        /// <summary>
        /// Контекст БД
        /// </summary>
        readonly protected InvcSysDBContext dBContext;
        /// <summary>
        /// Дата и время
        /// </summary>
        readonly protected IDateTimeOffsetProvider dateTime;

        private readonly CancellationToken cancellationToken;
        private readonly IWriteRepository<TObject> repository;
        private readonly DbSet<TObject> dbSet;

        /// <summary>
        /// Конструктор
        /// </summary>
        public BaseWriteRepositoryTests(DBTestsFixture fixture)
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
        /// Изменить только личные поля, но не общие для всех DBObject
        /// </summary>
        protected abstract void ChangeOwnFields(TObject obj);

        /// <summary>
        /// Создать никак не привязанную копию
        /// </summary>
        protected abstract TObject CreateUnboundCopy(TObject obj);

        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        protected abstract IWriteRepository<TObject> Repository();

        /// <summary>
        /// Выдаёт нужную таблицу БД
        /// </summary>
        protected abstract DbSet<TObject> DBSet();

        #endregion

        /// <summary>
        /// Добавление работает
        /// </summary>
        [Fact]
        public void AddShouldWork()
        {
            // Act
            repository.Add(NewDBObject());
            repository.Add(NewDBObject());
            dBContext.SaveChanges();

            // Assert
            IQueryable<TObject> result = dbSet;
            result.Should().HaveCount(2);
        }

        /// <summary>
        /// Удаление работает
        /// </summary>
        [Fact]
        public void DeleteShouldWork()
        {
            // Arrange
            var entity = NewDBObject();
            repository.Add(entity);
            dBContext.SaveChanges();

            // Act
            repository.Delete(entity);
            dBContext.SaveChanges();

            // Assert
            var result = dbSet.FirstOrDefault(x => x.Id == entity.Id);
            if (result != null)
            { result.DeletedDate.Should().NotBeNull(); }
            else
            { Assert.Fail(NotFoundErrorMessage); }
        }

        /// <summary>
        /// Обновление работает
        /// </summary>
        [Fact]
        public void UpdateShouldWork()
        {
            // Arrange
            var entity = NewDBObject();
            var oldEntity = CreateUnboundCopy(entity);
            var entityId = entity.Id;
            repository.Add(entity);
            dBContext.SaveChanges();

            var entityUpd = dbSet.FirstOrDefault(x => x.Id == entity.Id);

            if (entityUpd != null)
            { ChangeOwnFields(entityUpd); }
            else
            { Assert.Fail(NotFoundErrorMessage); }

            // Act
            repository.Update(entity);
            dBContext.SaveChanges();

            // Assert
            var result = dbSet.FirstOrDefault(x => x.Id == entity.Id);
            if (result != null)
            {
                result.Should()
                    .NotBeNull()
                    .And.BeEquivalentTo(entityUpd)
                    .And.NotBeEquivalentTo(oldEntity);
                result.UpdatedDate.Should().NotBeNull();
            }
            else
            { Assert.Fail(NotFoundErrorMessage); }
        }

        private void ClearDbSet()
        {
            dbSet.RemoveRange(dbSet);
            dBContext.SaveChanges();
        }
    }
}
