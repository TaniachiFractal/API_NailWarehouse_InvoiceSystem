using InvoiceSystem.Database.Contracts.ModelInterfaces;

namespace InvoiceSystem.Api.Models.Products
{
    /// <summary>
    /// Модель просмотра данных товара
    /// </summary>
    public class ProductApiModel : AddProductApiModel, IUniqueID
    {
        Guid IUniqueID.Id { get; set; }
    }
}
