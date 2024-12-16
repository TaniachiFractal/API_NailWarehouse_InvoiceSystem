using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Contracts.Sales;

namespace InvoiceSystem.Repositories.Sales
{
    /// <inheritdoc cref="ISaleReadRepository"/>
    public class SaleReadRepository : BaseReadRepository<Sale>, ISaleReadRepository
    {
        /// <inheritdoc/>
        public SaleReadRepository(IReader reader) : base(reader)
        {
        }
    }
}
