using InvoiceSystem.Models.Interfaces;

namespace InvoiceSystem.Models
{
    /// <inheritdoc cref="IFullInvoiceInfoModel{ProductInvoiceListingModel}"/>
    public class FullInvoiceInfoModel : IFullInvoiceInfoModel<ProductInvoiceListingModel>
    {
        /// <inheritdoc/>
        public Guid InvoiceId { get; set; }

        /// <inheritdoc/>
        public uint Number { get; set; }

        /// <inheritdoc/>
        public DateTime ExecDate { get; set; }

        /// <inheritdoc/>
        public Guid CustomerId { get; set; }

        /// <inheritdoc/>
        public string CustomerName { get; set; }

        /// <inheritdoc/>
        public string CustomerINN { get; set; }

        /// <inheritdoc/>
        public string CustomerAddress { get; set; }

        /// <inheritdoc/>
        public IEnumerable<ProductInvoiceListingModel> Products { get; set; }

        /// <inheritdoc/>
        public decimal Tax { get; set; }

        /// <inheritdoc/>
        public decimal FullSummary { get; set; }
    }
}
