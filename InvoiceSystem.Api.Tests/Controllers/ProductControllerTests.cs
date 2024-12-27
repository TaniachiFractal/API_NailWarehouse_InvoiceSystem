using Ahatornn.TestGenerator;
using InvoiceSystem.Api.Controllers;
using InvoiceSystem.Api.Models.Products;
using InvoiceSystem.Common;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Repositories.Products;
using InvoiceSystem.Services.Contracts;
using InvoiceSystem.Services.Models.Products;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Api.Tests.Controllers
{
    /// <summary>
    /// Тесты <see cref="ProductController"/>
    /// </summary>
    public class ProductControllerTests : DBObjectControllerBaseTests<AddProductApiModel, ProductApiModel, AddProductModel, ProductModel, Product>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ProductControllerTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override DBObjectController<AddProductApiModel, ProductApiModel, AddProductModel, ProductModel, Product> Controller()
            => new ProductController(mapper, service, validationService, logger);

        /// <inheritdoc/>
        protected override AddProductApiModel CorrectFields()
            => new()
            {
                Name = Com.NewString("Name"),
                Price = 99,
            };

        /// <inheritdoc/>
        protected override AddProductApiModel WrongFields()
            => new()
            {
                Name = "@",
                Price = -34
            };

        /// <inheritdoc/>
        protected override DbSet<Product> DBSet() => dBContext.Products;

        /// <inheritdoc/>
        protected override AddProductModel NewAddObjectModel() => TestEntityProvider.Shared.Create<AddProductModel>();

        /// <inheritdoc/>
        protected override Product NewDBObject() => TestEntityProvider.Shared.Create<Product>();

        /// <inheritdoc/>
        protected override ProductModel NewObjectModel() => TestEntityProvider.Shared.Create<ProductModel>();

        /// <inheritdoc/>
        protected override IDBobjectService<AddProductModel, ProductModel, Product> Service()
            => new ProductService(
                mapper,
                new ProductReadRepository(dBContext),
                new ProductWriteRepository(dBContext, dateTime, logger),
                dBContext
                );

        /// <inheritdoc/>
        protected override IDBObjectValidationService ValidationService()
            => new ProductValidationService();
    }
}
