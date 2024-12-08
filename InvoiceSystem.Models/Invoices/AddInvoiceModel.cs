using InvoiceSystem.Models.Interfaces;

namespace InvoiceSystem.Models.Invoices
{
    /// <summary>
    /// Модель для добавления и изменения накладной
    /// </summary>
    public class AddInvoiceModel : IInvoice
    {
        /// <inheritdoc/> 
        public Guid CustomerId { get; set; }

        /// <inheritdoc/> 
        public DateTimeOffset ExecutionDate { get; set; }
    }
}
