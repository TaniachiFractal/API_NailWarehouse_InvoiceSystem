using InvoiceSystem.Models.Products;

namespace InvoiceSystem.Services.Contracts.Models.Products
{
    /// <summary>
    /// Сервис товаров
    /// </summary>
    public interface IProductService : IDBobjectService<AddProductModel, ProductModel, Product>
    {
    }
}
