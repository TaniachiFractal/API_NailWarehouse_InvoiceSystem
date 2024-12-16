using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Repositories.Contracts.Customers;

namespace InvoiceSystem.Repositories.Customers
{
    /// <inheritdoc cref="ICustomerReadRepository"/>
    public class CustomerReadRepository : BaseReadRepository<Customer>, ICustomerReadRepository
    {
        /// <inheritdoc/>
        public CustomerReadRepository(IReader reader) : base(reader)
        {
        }
    }
}
