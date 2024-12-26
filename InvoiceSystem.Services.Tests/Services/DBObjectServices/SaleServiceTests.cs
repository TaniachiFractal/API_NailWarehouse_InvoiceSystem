using Ahatornn.TestGenerator;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Sales;
using InvoiceSystem.Services.Models.Sales;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Services.Tests.Services.DBObjectServices
{
    /// <summary>
    /// Тесты <see cref="SaleService"/>
    /// </summary>
    public class SaleServiceTests : DBObjectServiceBaseTests<AddSaleModel, SaleModel, Sale, SaleService>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public SaleServiceTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override DbSet<Sale> DBSet()
            => dBContext.Sales;

        /// <inheritdoc/>
        protected override AddSaleModel NewAddObjectModel()
            => TestEntityProvider.Shared.Create<AddSaleModel>();

        /// <inheritdoc/>
        protected override Sale NewDBObject()
            => TestEntityProvider.Shared.Create<Sale>();

        /// <inheritdoc/>
        protected override SaleModel NewObjectModel()
            => TestEntityProvider.Shared.Create<SaleModel>();

        /// <inheritdoc/>
        protected override SaleService Service()
            => new
            (
                mapper,
                new SaleReadRepository(dBContext),
                new SaleWriteRepository(dBContext, dateTime),
                dBContext
            );
    }
}
