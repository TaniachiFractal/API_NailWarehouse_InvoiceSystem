using InvoiceSystem.Database.Contracts.ModelInterfaces;

namespace InvoiceSystem.Models.Customers
{
    /// <summary>
    /// Модель просмотра данных покупателя
    /// </summary>
    public class CustomerModel : AddCustomerModel, IUniqueID
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }
    }
}
