using InvoiceSystem.Common;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Repositories.Contracts.Invoices;
using Microsoft.Extensions.Logging;

namespace InvoiceSystem.Repositories.Invoices
{
    /// <inheritdoc cref="IInvoiceWriteRepository"/>
    public class InvoiceWriteRepository : BaseWriteRepository<Invoice>, IInvoiceWriteRepository
    {
        /// <inheritdoc/>
        public InvoiceWriteRepository(IWriter writer, IDateTimeOffsetProvider dateTimeOffsetProvider, ILogger<InvoiceWriteRepository> logger)
            : base(writer, dateTimeOffsetProvider, logger)
        {
        }

        /// <summary>
        /// Конструктор без специфичного логгера
        /// </summary>
        public InvoiceWriteRepository(IWriter writer, IDateTimeOffsetProvider dateTimeOffsetProvider, ILogger logger) : base(writer, dateTimeOffsetProvider, logger)
        {
        }
    }
}
