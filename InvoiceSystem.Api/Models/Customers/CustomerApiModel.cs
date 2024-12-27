using InvoiceSystem.Database.Contracts.ModelInterfaces;

namespace InvoiceSystem.Api.Models.Customers
{
    /// <summary>
    /// Модель просмотра данных покупателя
    /// </summary>
    public class CustomerApiModel : AddCustomerApiModel, IUniqueID
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }
    }
}
