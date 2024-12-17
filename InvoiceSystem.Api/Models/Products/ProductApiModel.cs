using InvoiceSystem.Database.Contracts.ModelInterfaces;

namespace InvoiceSystem.Api.Models.Products
{
    /// <summary>
    /// Модель просмотра данных товара
    /// </summary>
    public class ProductApiModel : AddProductApiModel, IUniqueID
    {
        /// <inheritdoc/> 
        public Guid Id { get; set; }
    }
}
