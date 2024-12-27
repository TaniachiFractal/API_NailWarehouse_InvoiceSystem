using Ahatornn.TestGenerator;
using InvoiceSystem.Api.Controllers;
using InvoiceSystem.Api.Models.Customers;
using InvoiceSystem.Common;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Repositories.Customers;
using InvoiceSystem.Services.Contracts;
using InvoiceSystem.Services.Models.Customers;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Api.Tests.Controllers
{
    /// <summary>
    /// Тесты <see cref="CustomerController"/>
    /// </summary>
    public class CustomerControllerTests : DBObjectControllerBaseTests<AddCustomerApiModel, CustomerApiModel, AddCustomerModel, CustomerModel, Customer>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CustomerControllerTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override DBObjectController<AddCustomerApiModel, CustomerApiModel, AddCustomerModel, CustomerModel, Customer> Controller()
            => new CustomerController(mapper, service, validationService, logger);

        /// <inheritdoc/>
        protected override AddCustomerApiModel CorrectFields()
            => new()
            {
                Name = Com.NewString("Name"),
                INN = Com.NewINN(),
                Address = Com.NewString("Address"),
            };

        /// <inheritdoc/>
        protected override AddCustomerApiModel WrongFields()
            => new()
            {
                Name = "@",
                INN = "@",
                Address = "@",
            };

        /// <inheritdoc/>
        protected override DbSet<Customer> DBSet() => dBContext.Customers;

        /// <inheritdoc/>
        protected override AddCustomerModel NewAddObjectModel() => TestEntityProvider.Shared.Create<AddCustomerModel>();

        /// <inheritdoc/>
        protected override Customer NewDBObject() => TestEntityProvider.Shared.Create<Customer>();

        /// <inheritdoc/>
        protected override CustomerModel NewObjectModel() => TestEntityProvider.Shared.Create<CustomerModel>();

        /// <inheritdoc/>
        protected override IDBobjectService<AddCustomerModel, CustomerModel, Customer> Service()
            => new CustomerService(
                mapper,
                new CustomerReadRepository(dBContext),
                new CustomerWriteRepository(dBContext, dateTime, logger),
                dBContext
                );

        /// <inheritdoc/>
        protected override IDBObjectValidationService ValidationService()
            => new CustomerValidationService(new CustomerReadRepository(dBContext));

    }
}
