using InvoiceSystem.Common;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Repositories.Contracts.Products;

namespace InvoiceSystem.Repositories.Products
{
    /// <inheritdoc cref="IProductWriteRepository"/>
    public class ProductWriteRepository : BaseWriteRepository<Product>, IProductWriteRepository
    {
        /// <inheritdoc/>
        public ProductWriteRepository(IWriter writer, IDateTimeOffsetProvider dateTimeOffsetProvider) : base(writer, dateTimeOffsetProvider)
        {
        }
    }
}
