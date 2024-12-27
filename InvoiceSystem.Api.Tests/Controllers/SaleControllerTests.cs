using Ahatornn.TestGenerator;
using InvoiceSystem.Api.Controllers;
using InvoiceSystem.Api.Models.Sales;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Invoices;
using InvoiceSystem.Repositories.Products;
using InvoiceSystem.Repositories.Sales;
using InvoiceSystem.Services.Contracts;
using InvoiceSystem.Services.Models.Sales;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Api.Tests.Controllers
{
    /// <summary>
    /// Тесты <see cref="SaleController"/>
    /// </summary>
    public class SaleControllerTests : DBObjectControllerBaseTests<AddSaleApiModel, SaleApiModel, AddSaleModel, SaleModel, Sale>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public SaleControllerTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override DBObjectController<AddSaleApiModel, SaleApiModel, AddSaleModel, SaleModel, Sale> Controller()
            => new SaleController(mapper, service, validationService, logger);

        /// <inheritdoc/>
        protected override AddSaleApiModel CorrectFields()
        {
            var invoice = TestEntityProvider.Shared.Create<Invoice>();
            var product = TestEntityProvider.Shared.Create<Product>();
            dBContext.Add(invoice);
            dBContext.Add(product);
            dBContext.SaveChanges();

            return new()
            {
                InvoiceId = invoice.Id,
                ProductId = product.Id,
                SoldCount = 3
            };
        }

        /// <inheritdoc/>
        protected override AddSaleApiModel WrongFields()
            => new()
            {
                InvoiceId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                SoldCount = -34
            };

        /// <inheritdoc/>
        protected override DbSet<Sale> DBSet() => dBContext.Sales;

        /// <inheritdoc/>
        protected override AddSaleModel NewAddObjectModel() => TestEntityProvider.Shared.Create<AddSaleModel>();

        /// <inheritdoc/>
        protected override Sale NewDBObject() => TestEntityProvider.Shared.Create<Sale>();

        /// <inheritdoc/>
        protected override SaleModel NewObjectModel() => TestEntityProvider.Shared.Create<SaleModel>();

        /// <inheritdoc/>
        protected override IDBobjectService<AddSaleModel, SaleModel, Sale> Service()
            => new SaleService(
                mapper,
                new SaleReadRepository(dBContext),
                new SaleWriteRepository(dBContext, dateTime, logger),
                dBContext
                );

        /// <inheritdoc/>
        protected override IDBObjectValidationService ValidationService()
            => new SaleValidationService(new ProductReadRepository(dBContext), new InvoiceReadRepository(dBContext));

    }
}
