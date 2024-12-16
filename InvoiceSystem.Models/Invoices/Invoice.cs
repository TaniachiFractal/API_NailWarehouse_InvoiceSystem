using InvoiceSystem.Database.Contracts;
using InvoiceSystem.Models.Interfaces;

namespace InvoiceSystem.Models.Invoices
{
    /// <summary>
    /// Товарная накладная
    /// </summary>
    public class Invoice : DBObject, IInvoice
    {
        /// <inheritdoc/> 
        public Guid CustomerId { get; set; }

        /// <inheritdoc/> 
        public DateTimeOffset ExecutionDate { get; set; }
    }
}
