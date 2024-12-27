using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Invoices;

namespace InvoiceSystem.Repositories.Contracts.Invoices
{
    /// <summary>
    /// Читает из таблицы <see cref="Invoice"/>s
    /// </summary>
    public interface IInvoiceReadRepository : IReadRepository<Invoice>
    {
    }
}
