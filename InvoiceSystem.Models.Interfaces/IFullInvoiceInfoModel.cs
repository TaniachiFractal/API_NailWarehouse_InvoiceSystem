namespace InvoiceSystem.Models.Interfaces
{
    /// <summary>
    /// Модель всех данных накладной вместе
    /// </summary>
    public interface IFullInvoiceInfoModel<TProductListing> where TProductListing : IProductInvoiceListingModel
    {
        /// <summary>
        /// ID накладной
        /// </summary>
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public uint Number { get; set; }

        /// <summary>
        /// Дата исполнения
        /// </summary>
        public DateTime ExecDate { get; set; }

        /// <summary>
        /// ID покупателя
        /// </summary>
        public Guid CustomerId { get; set; }

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
        public IEnumerable<TProductListing> Products { get; set; }

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
