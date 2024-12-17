namespace InvoiceSystem.Api.Models
{
    /// <summary>
    /// Модель записи о товаре в накладной
    /// </summary>
    public class ProductInvoiceListing
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public string Count { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public string Summary { get; set; }
    }
}
