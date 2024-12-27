using Ahatornn.TestGenerator;
using FluentAssertions;
using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Contracts.Sales;
using InvoiceSystem.Repositories.Sales;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InvoiceSystem.Repositories.Tests.ReadRepositories
{
    /// <summary>
    /// Тесты <see cref="SaleReadRepository"/>
    /// </summary>
    public class SaleReadRepositoryTests : BaseReadRepositoryTests<Sale>
    {
        private readonly ISaleReadRepository saleReadRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public SaleReadRepositoryTests(DBTestsFixture fixture) : base(fixture)
        {
            saleReadRepository = (ISaleReadRepository)repository;
        }

        /// <inheritdoc/>
        protected override DbSet<Sale> DBSet()
            => dBContext.Sales;

        /// <inheritdoc/>
        protected override Sale NewDBObject()
            => TestEntityProvider.Shared.Create<Sale>();

        /// <inheritdoc/>
        protected override IReadRepository<Sale> Repository()
            => new SaleReadRepository(dBContext);

        /// <summary>
        /// Есть другие продажи, но с другой накладной, он не возвращает
        /// </summary>
        [Fact]
        public async Task GetAllWithInvoiceIdReturnsOne()
        {
            // Arrange
            var obj = NewDBObject();
            dbSet.AddRange(obj, NewDBObject(), NewDBObject(), NewDBObject());
            dBContext.SaveChanges();

            // Act
            var result =
                await saleReadRepository
                .GetAllWithInvoiceId(obj.InvoiceId, cancellationToken);

            // Assert
            result.Should()
                .NotBeEmpty()
                .And.HaveCount(1)
                .And.ContainSingle(x => x.Id == obj.Id);
        }
    }
}
