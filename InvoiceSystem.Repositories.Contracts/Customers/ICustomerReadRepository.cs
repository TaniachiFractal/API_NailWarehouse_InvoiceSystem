using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Customers;

namespace InvoiceSystem.Repositories.Contracts.Customers
{
    /// <summary>
    /// Читает из таблицы <see cref="Customer"/>s
    /// </summary>
    public interface ICustomerReadRepository : IReadRepository<Customer>
    {
    }
}
