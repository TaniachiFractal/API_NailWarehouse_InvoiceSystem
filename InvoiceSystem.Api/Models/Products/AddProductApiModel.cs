using InvoiceSystem.Models.Interfaces;

namespace InvoiceSystem.Api.Models.Products
{
    /// <summary>
    /// Модель для добавления и изменения данных товара
    /// </summary>
    public class AddProductApiModel : IProduct
    {
        /// <inheritdoc/> 
        public string Name { get; set; }

        /// <inheritdoc/> 
        public decimal Price { get; set; }
    }

}
