using Ahatornn.TestGenerator;
using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Repositories.Products;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Repositories.Tests.ReadRepositories
{
    /// <summary>
    /// Тесты <see cref="ProductReadRepository"/>
    /// </summary>
    public class ProductReadRepositoryTests : BaseReadRepositoryTests<Product>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ProductReadRepositoryTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override DbSet<Product> DBSet()
            => dBContext.Products;

        /// <inheritdoc/>
        protected override Product NewDBObject()
            => TestEntityProvider.Shared.Create<Product>();

        /// <inheritdoc/>
        protected override IReadRepository<Product> Repository()
            => new ProductReadRepository(dBContext);
    }
}
