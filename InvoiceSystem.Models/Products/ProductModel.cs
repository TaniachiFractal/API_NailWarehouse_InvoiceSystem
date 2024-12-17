using InvoiceSystem.Database.Contracts.ModelInterfaces;

namespace InvoiceSystem.Models.Products
{
    /// <summary>
    /// Модель просмотра данных товара
    /// </summary>
    public class ProductModel : AddProductModel, IUniqueID
    {
        /// <inheritdoc/> 
        public Guid Id { get; set; }
    }
}
