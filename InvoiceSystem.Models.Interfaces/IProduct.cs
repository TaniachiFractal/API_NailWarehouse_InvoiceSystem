namespace InvoiceSystem.Models.Interfaces
{
    /// <summary>
    /// Имеет поля данных товара
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Название
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Цена в рублях
        /// </summary>
        public decimal Price { get; set; }
    }
}
