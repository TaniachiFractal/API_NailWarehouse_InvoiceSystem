using InvoiceSystem.Common;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Repositories.Contracts.Customers;
using Microsoft.Extensions.Logging;

namespace InvoiceSystem.Repositories.Customers
{
    /// <inheritdoc cref="ICustomerWriteRepository"/>
    public class CustomerWriteRepository : BaseWriteRepository<Customer>, ICustomerWriteRepository
    {
        /// <inheritdoc/>
        public CustomerWriteRepository(IWriter writer, IDateTimeOffsetProvider dateTimeOffsetProvider, ILogger<CustomerWriteRepository> logger)
            : base(writer, dateTimeOffsetProvider, logger)
        {
        }

        /// <summary>
        /// Конструктор без специфичного логгера
        /// </summary>
        public CustomerWriteRepository(IWriter writer, IDateTimeOffsetProvider dateTimeOffsetProvider, ILogger logger) : base(writer, dateTimeOffsetProvider, logger)
        {
        }
    }
}
