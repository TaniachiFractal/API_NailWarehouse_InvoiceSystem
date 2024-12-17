namespace InvoiceSystem.Api.Models
{
    /// <summary>
    /// Модель всех данных накладной вместе
    /// </summary>
    public class FullInvoiceInfoModel
    {
        /// <summary>
        /// Номер
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Дата исполнения
        /// </summary>
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
        public IEnumerable<ProductInvoiceListing> Products { get; set; }

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
