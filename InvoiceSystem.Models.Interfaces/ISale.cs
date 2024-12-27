namespace InvoiceSystem.Models.Interfaces
{
    /// <summary>
    /// Имеет поля данных записи о продаже товара
    /// </summary>
    public interface ISale
    {
        /// <summary>
        /// ID товара
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// ID накладной
        /// </summary>
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// Количество проданных единиц товара
        /// </summary>
        public int SoldCount { get; set; }
    }
}
