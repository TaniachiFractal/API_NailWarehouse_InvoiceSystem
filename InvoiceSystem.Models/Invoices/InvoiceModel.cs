using InvoiceSystem.Database.Contracts.ModelInterfaces;

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
