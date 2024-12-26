using Ahatornn.TestGenerator;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Repositories.Products;
using InvoiceSystem.Services.Models.Products;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Services.Tests.Services.DBObjectServices
{
    /// <summary>
    /// Тесты <see cref="ProductService"/>
    /// </summary>
    public class ProductServiceTests : DBObjectServiceBaseTests<AddProductModel, ProductModel, Product, ProductService>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ProductServiceTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override DbSet<Product> DBSet()
            => dBContext.Products;

        /// <inheritdoc/>
        protected override AddProductModel NewAddObjectModel()
            => TestEntityProvider.Shared.Create<AddProductModel>();

        /// <inheritdoc/>
        protected override Product NewDBObject()
            => TestEntityProvider.Shared.Create<Product>();

        /// <inheritdoc/>
        protected override ProductModel NewObjectModel()
            => TestEntityProvider.Shared.Create<ProductModel>();

        /// <inheritdoc/>
        protected override ProductService Service()
            => new
            (
                mapper,
                new ProductReadRepository(dBContext),
                new ProductWriteRepository(dBContext, dateTime),
                dBContext
            );
    }
}
