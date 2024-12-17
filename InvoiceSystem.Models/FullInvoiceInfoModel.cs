using InvoiceSystem.Models.Interfaces;

namespace InvoiceSystem.Models
{
    /// <inheritdoc cref="IFullInvoiceInfoModel{ProductInvoiceListingModel}"/>
    public class FullInvoiceInfoModel : IFullInvoiceInfoModel<ProductInvoiceListingModel>
    {
        /// <inheritdoc/>
        public int Number { get; set; }

        /// <inheritdoc/>
        public DateTime ExecDate { get; set; }

        /// <summary>
        /// Имя покупателя
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// ИНН покупателя
        /// </summary>
        public string CustomerINN { get; set; }

        /// <summary>
        /// Адрес покупателя
        /// </summary>
        public string CustomerAddress { get; set; }

        /// <summary>
        /// Список записей о товарах
        /// </summary>
        public IEnumerable<ProductInvoiceListingModel> Products { get; set; }

        /// <summary>
        /// Налог
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// Итого
        /// </summary>
        public decimal FullSummary { get; set; }
    }
}
