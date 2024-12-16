using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Customers;

namespace InvoiceSystem.Repositories.Contracts.Customers
{
    /// <summary>
    /// Пишет в таблицу <see cref="Customer"/>s
    /// </summary>
    public interface ICustomerWriteRepository : IWriteRepository<Customer>
    {
    }
}
