using InvoiceSystem.Common;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Repositories.Contracts.Invoices;

namespace InvoiceSystem.Repositories.Invoices
{
    /// <inheritdoc cref="IInvoiceWriteRepository"/>
    public class InvoiceWriteRepository : BaseWriteRepository<Invoice>, IInvoiceWriteRepository
    {
        /// <inheritdoc/>
        public InvoiceWriteRepository(IWriter writer, IDateTimeOffsetProvider dateTimeOffsetProvider) : base(writer, dateTimeOffsetProvider)
        {
        }
    }
}
