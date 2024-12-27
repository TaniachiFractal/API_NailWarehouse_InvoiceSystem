using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Products;

namespace InvoiceSystem.Repositories.Contracts.Products
{
    /// <summary>
    /// Читает из таблицы <see cref="Product"/>s
    /// </summary>
    public interface IProductReadRepository : IReadRepository<Product>
    {
    }
}
