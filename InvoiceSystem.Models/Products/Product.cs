using InvoiceSystem.Models.Interfaces;

namespace InvoiceSystem.Models.Products
{
    /// <summary>
    /// Товар на складе
    /// </summary>
    public class Product : DBObject, IProduct
    {
        /// <inheritdoc/> 
        public string Name { get; set; }

        /// <inheritdoc/> 
        public decimal Price { get; set; }

    }
}
