using InvoiceSystem.Common;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Repositories.Contracts.Customers;

namespace InvoiceSystem.Repositories.Customers
{
    /// <inheritdoc cref="ICustomerWriteRepository"/>
    public class CustomerWriteRepository : BaseWriteRepository<Customer>, ICustomerWriteRepository
    {
        /// <inheritdoc/>
        public CustomerWriteRepository(IWriter writer, IDateTimeOffsetProvider dateTimeOffsetProvider) : base(writer, dateTimeOffsetProvider)
        {
        }
    }
}
