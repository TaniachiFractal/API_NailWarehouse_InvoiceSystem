using Ahatornn.TestGenerator;
using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Sales;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Repositories.Tests.ReadRepositories
{
    /// <summary>
    /// Тесты <see cref="SaleReadRepository"/>
    /// </summary>
    public class SaleReadRepositoryTests : BaseReadRepositoryTests<Sale>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public SaleReadRepositoryTests(DBTestsFixture fixture) : base(fixture)
        {
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
    }
}
