using Ahatornn.TestGenerator;
using InvoiceSystem.Api.Controllers;
using InvoiceSystem.Api.Models.Invoices;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Repositories.Customers;
using InvoiceSystem.Repositories.Invoices;
using InvoiceSystem.Services.Contracts;
using InvoiceSystem.Services.Models.Invoices;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Api.Tests.Controllers
{
    /// <summary>
    /// Тесты <see cref="InvoiceController"/>
    /// </summary>
    public class InvoiceControllerTests : DBObjectControllerBaseTests<AddInvoiceApiModel, InvoiceApiModel, AddInvoiceModel, InvoiceModel, Invoice>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public InvoiceControllerTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override DBObjectController<AddInvoiceApiModel, InvoiceApiModel, AddInvoiceModel, InvoiceModel, Invoice> Controller()
            => new InvoiceController(mapper, service, validationService, logger);

        /// <inheritdoc/>
        protected override AddInvoiceApiModel CorrectFields()
        {
            var customer = TestEntityProvider.Shared.Create<Customer>();
            dBContext.Add(customer);
            dBContext.SaveChanges();

            return new()
            {
                CustomerId = customer.Id,
                ExecutionDate = dateTime.UtcNow.Date,
            };
        }

        /// <inheritdoc/>
        protected override AddInvoiceApiModel WrongFields()
            => new()
            {
                CustomerId = Guid.NewGuid()
            };

        /// <inheritdoc/>
        protected override DbSet<Invoice> DBSet() => dBContext.Invoices;

        /// <inheritdoc/>
        protected override AddInvoiceModel NewAddObjectModel() => TestEntityProvider.Shared.Create<AddInvoiceModel>();

        /// <inheritdoc/>
        protected override Invoice NewDBObject() => TestEntityProvider.Shared.Create<Invoice>();

        /// <inheritdoc/>
        protected override InvoiceModel NewObjectModel() => TestEntityProvider.Shared.Create<InvoiceModel>();

        /// <inheritdoc/>
        protected override IDBobjectService<AddInvoiceModel, InvoiceModel, Invoice> Service()
            => new InvoiceService(
                mapper,
                new InvoiceReadRepository(dBContext),
                new InvoiceWriteRepository(dBContext, dateTime, logger),
                dBContext
                );

        /// <inheritdoc/>
        protected override IDBObjectValidationService ValidationService()
            => new InvoiceValidationService(new CustomerReadRepository(dBContext));

    }
}
