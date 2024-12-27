using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Repositories.Contracts.Products;

namespace InvoiceSystem.Repositories.Products
{
    /// <inheritdoc cref="IProductReadRepository"/>
    public class ProductReadRepository : BaseReadRepository<Product>, IProductReadRepository
    {
        /// <inheritdoc/>
        public ProductReadRepository(IReader reader) : base(reader)
        {
        }
    }
}
