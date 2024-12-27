using InvoiceSystem.Common;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Contracts.Sales;
using Microsoft.Extensions.Logging;

namespace InvoiceSystem.Repositories.Sales
{
    /// <inheritdoc/>
    public class SaleWriteRepository : BaseWriteRepository<Sale>, ISaleWriteRepository
    {
        /// <inheritdoc/>
        public SaleWriteRepository(IWriter writer, IDateTimeOffsetProvider dateTimeOffsetProvider, ILogger<SaleWriteRepository> logger)
            : base(writer, dateTimeOffsetProvider, logger)
        {
        }

        /// <summary>
        /// Конструктор без специфичного логгера
        /// </summary>
        public SaleWriteRepository(IWriter writer, IDateTimeOffsetProvider dateTimeOffsetProvider, ILogger logger) : base(writer, dateTimeOffsetProvider, logger)
        {
        }
    }
}
