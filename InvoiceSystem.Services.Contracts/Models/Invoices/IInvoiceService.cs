using InvoiceSystem.Models.Invoices;

namespace InvoiceSystem.Services.Contracts.Models.Invoices
{
    /// <summary>
    /// Сервис накладных
    /// </summary>
    public interface IInvoiceService : IDBobjectService<AddInvoiceModel, InvoiceModel, Invoice>
    {
    }
}
