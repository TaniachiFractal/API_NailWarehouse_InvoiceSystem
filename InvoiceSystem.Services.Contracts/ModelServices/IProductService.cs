using InvoiceSystem.Models.Products;

namespace InvoiceSystem.Services.Contracts.ModelServices
{
    /// <summary>
    /// Сервиc для <see cref="Product"/>
    /// </summary>
    public interface IProductService : IDBobjectService
    {
        /// <summary>
        /// Получить ID товара по имени
        /// </summary>
        Task<Product> GetIdByName(string name, CancellationToken cancellationToken);
    }
}
