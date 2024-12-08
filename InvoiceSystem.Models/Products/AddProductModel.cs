using InvoiceSystem.Models.Interfaces;

namespace InvoiceSystem.Models.Products
{
    /// <summary>
    /// Модель для добавления и изменения данных товара
    /// </summary>
    public class AddProductModel : IProduct
    {
        /// <inheritdoc/> 
        public string? Name { get; set; }

        /// <inheritdoc/> 
        public decimal Price { get; set; }
    }

}
