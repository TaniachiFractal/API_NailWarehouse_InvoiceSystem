using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Products;

namespace InvoiceSystem.Repositories.Contracts.Products
{
    /// <summary>
    /// Пишет в таблицу <see cref="Product"/>s
    /// </summary>
    public interface IProductWriteRepository : IWriteRepository<Product>
    {
    }
}
