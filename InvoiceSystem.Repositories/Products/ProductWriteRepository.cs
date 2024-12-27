using InvoiceSystem.Common;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Repositories.Contracts.Products;
using Microsoft.Extensions.Logging;

namespace InvoiceSystem.Repositories.Products
{
    /// <inheritdoc cref="IProductWriteRepository"/>
    public class ProductWriteRepository : BaseWriteRepository<Product>, IProductWriteRepository
    {
        /// <inheritdoc/>
        public ProductWriteRepository(IWriter writer, IDateTimeOffsetProvider dateTimeOffsetProvider, ILogger<ProductWriteRepository> logger)
            : base(writer, dateTimeOffsetProvider, logger)
        {
        }

        /// <summary>
        /// Конструктор без специфичного логгера
        /// </summary>
        public ProductWriteRepository(IWriter writer, IDateTimeOffsetProvider dateTimeOffsetProvider, ILogger logger) : base(writer, dateTimeOffsetProvider, logger)
        {
        }
    }
}
