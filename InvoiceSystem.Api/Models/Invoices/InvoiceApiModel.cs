using InvoiceSystem.Database.Contracts.ModelInterfaces;

namespace InvoiceSystem.Api.Models.Invoices
{
    /// <summary>
    /// Модель просмотра данных накладной
    /// </summary>
    public class InvoiceApiModel : AddInvoiceApiModel, IUniqueID
    {
        /// <inheritdoc/> 
        public Guid Id { get; set; }
    }
}
