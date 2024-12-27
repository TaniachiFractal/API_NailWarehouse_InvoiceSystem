using InvoiceSystem.Models.Interfaces;

namespace InvoiceSystem.Api.Models.Customers
{
    /// <summary>
    /// Модель для добавления и изменения покупателя
    /// </summary>
    public class AddCustomerApiModel : ICustomer
    {
        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public string INN { get; set; }

        /// <inheritdoc/>
        public string Address { get; set; }
    }
}
