using Ahatornn.TestGenerator;
using InvoiceSystem.Common;
using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Repositories.Customers;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Repositories.Tests.WriteRepositories
{
    /// <summary>
    /// Тесты <see cref="CustomerWriteRepository"/>
    /// </summary>
    public class CustomerWriteRepositoryTests : BaseWriteRepositoryTests<Customer>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CustomerWriteRepositoryTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override void ChangeOwnFields(Customer obj)
        {
            obj.INN = Com.NewINN();
            obj.Address = Com.NewString(nameof(obj.Address));
            obj.Name = Com.NewString(nameof(obj.Name));
        }

        /// <inheritdoc/>
        protected override Customer CreateUnboundCopy(Customer obj)
        => new()
        {
            Id = obj.Id,
            Name = obj.Name,
            Address = obj.Address,
            INN = obj.INN,
            CreatedDate = obj.CreatedDate,
            DeletedDate = obj.DeletedDate,
            UpdatedDate = obj.UpdatedDate
        };

        /// <inheritdoc/>
        protected override DbSet<Customer> DBSet()
            => dBContext.Customers;

        /// <inheritdoc/>
        protected override Customer NewDBObject()
            => TestEntityProvider.Shared.Create<Customer>();

        /// <inheritdoc/>
        protected override IWriteRepository<Customer> Repository()
            => new CustomerWriteRepository(dBContext, dateTime);
    }
}
