using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Invoices;

namespace InvoiceSystem.Repositories.Contracts.Invoices
{
    /// <summary>
    /// Пишет в таблицу <see cref="Invoice"/>s
    /// </summary>
    public interface IInvoiceWriteRepository : IWriteRepository<Invoice>
    {
    }
}
