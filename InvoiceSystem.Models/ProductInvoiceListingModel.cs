using InvoiceSystem.Models.Interfaces;

namespace InvoiceSystem.Models
{
    /// <inheritdoc cref="IProductInvoiceListingModel"/>
    public class ProductInvoiceListingModel : IProductInvoiceListingModel
    {
        /// <inheritdoc/>
        public Guid ProductId { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public int Count { get; set; }

        /// <inheritdoc/>
        public decimal Price { get; set; }

        /// <inheritdoc/>
        public decimal Summary { get; set; }
    }
}
