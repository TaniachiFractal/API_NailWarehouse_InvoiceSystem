using InvoiceSystem.Database.Contracts;

namespace InvoiceSystem.Models.Invoices
{
    /// <summary>
    /// Модель просмотра данных накладной
    /// </summary>
    public class InvoiceModel : AddInvoiceModel, IUniqueID
    {
        /// <inheritdoc/> 
        public Guid Id { get; set; }
    }
}
