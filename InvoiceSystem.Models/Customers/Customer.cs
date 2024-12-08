using InvoiceSystem.Models.Interfaces;

namespace InvoiceSystem.Models.Customers
{
    /// <summary>
    /// Покупатель
    /// </summary>
    public class Customer : DBObject, ICustomer
    {
        /// <inheritdoc/>
        public string? Name { get; set; }

        /// <inheritdoc/>
        public string? INN { get; set; }

        /// <inheritdoc/>
        public string? Address { get; set; }
    }
}
