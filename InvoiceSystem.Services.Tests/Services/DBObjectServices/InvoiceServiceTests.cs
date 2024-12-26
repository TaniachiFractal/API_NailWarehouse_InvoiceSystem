using Ahatornn.TestGenerator;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Repositories.Invoices;
using InvoiceSystem.Services.Models.Invoices;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Services.Tests.Services.DBObjectServices
{
    /// <summary>
    /// Тесты <see cref="InvoiceService"/>
    /// </summary>
    public class InvoiceServiceTests : DBObjectServiceBaseTests<AddInvoiceModel, InvoiceModel, Invoice, InvoiceService>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public InvoiceServiceTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override DbSet<Invoice> DBSet()
            => dBContext.Invoices;

        /// <inheritdoc/>
        protected override AddInvoiceModel NewAddObjectModel()
            => TestEntityProvider.Shared.Create<AddInvoiceModel>();

        /// <inheritdoc/>
        protected override Invoice NewDBObject()
            => TestEntityProvider.Shared.Create<Invoice>();

        /// <inheritdoc/>
        protected override InvoiceModel NewObjectModel()
            => TestEntityProvider.Shared.Create<InvoiceModel>();

        /// <inheritdoc/>
        protected override InvoiceService Service()
            => new
            (
                mapper,
                new InvoiceReadRepository(dBContext),
                new InvoiceWriteRepository(dBContext, dateTime),
                dBContext
            );
    }
}
