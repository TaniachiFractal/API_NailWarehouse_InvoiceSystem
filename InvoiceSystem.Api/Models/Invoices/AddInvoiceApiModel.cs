using InvoiceSystem.Models.Interfaces;

namespace InvoiceSystem.Api.Models.Invoices
{
    /// <summary>
    /// Модель для добавления и изменения накладной
    /// </summary>
    public class AddInvoiceApiModel : IInvoice
    {
        /// <inheritdoc/> 
        public Guid CustomerId { get; set; }

        /// <inheritdoc/> 
        public DateTimeOffset ExecutionDate { get; set; }
    }
}
