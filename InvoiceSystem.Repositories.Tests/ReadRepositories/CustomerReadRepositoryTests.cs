using Ahatornn.TestGenerator;
using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Repositories.Customers;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Repositories.Tests.ReadRepositories
{
    /// <summary>
    /// Тесты <see cref="CustomerReadRepository"/>
    /// </summary>
    public class CustomerReadRepositoryTests : BaseReadRepositoryTests<Customer>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CustomerReadRepositoryTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override DbSet<Customer> DBSet()
            => dBContext.Customers;

        /// <inheritdoc/>
        protected override Customer NewDBObject()
            => TestEntityProvider.Shared.Create<Customer>();

        /// <inheritdoc/>
        protected override IReadRepository<Customer> Repository()
            => new CustomerReadRepository(dBContext);
    }
}
