namespace InvoiceSystem.Models.Interfaces
{
    /// <summary>
    /// Модель записи о товаре в накладной
    /// </summary>
    public interface IProductInvoiceListingModel
    {
        /// <summary>
        /// ID товара
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Summary { get; set; }
    }
}
