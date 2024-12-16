using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Repositories.Contracts.Invoices;

namespace InvoiceSystem.Repositories.Invoices
{
    /// <inheritdoc cref="IInvoiceReadRepository"/>
    public class InvoiceReadRepository : BaseReadRepository<Invoice>, IInvoiceReadRepository
    {
        /// <inheritdoc/>
        public InvoiceReadRepository(IReader reader) : base(reader)
        {
        }
    }
}
