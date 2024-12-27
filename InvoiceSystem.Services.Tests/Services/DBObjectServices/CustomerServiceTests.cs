using Ahatornn.TestGenerator;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Repositories.Customers;
using InvoiceSystem.Services.Models.Customers;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Services.Tests.Services.DBObjectServices
{
    /// <summary>
    /// Тесты <see cref="CustomerService"/>
    /// </summary>
    public class CustomerServiceTests : DBObjectServiceBaseTests<AddCustomerModel, CustomerModel, Customer, CustomerService>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CustomerServiceTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override DbSet<Customer> DBSet()
            => dBContext.Customers;

        /// <inheritdoc/>
        protected override AddCustomerModel NewAddObjectModel()
            => TestEntityProvider.Shared.Create<AddCustomerModel>();

        /// <inheritdoc/>
        protected override Customer NewDBObject()
            => TestEntityProvider.Shared.Create<Customer>();

        /// <inheritdoc/>
        protected override CustomerModel NewObjectModel()
            => TestEntityProvider.Shared.Create<CustomerModel>();

        /// <inheritdoc/>
        protected override CustomerService Service()
            => new
            (
                mapper,
                new CustomerReadRepository(dBContext),
                new CustomerWriteRepository(dBContext, dateTime, logger),
                dBContext
            );
    }
}
