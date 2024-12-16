using InvoiceSystem.Common;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Contracts.Sales;

namespace InvoiceSystem.Repositories.Sales
{
    /// <inheritdoc/>
    public class SaleWriteRepository : BaseWriteRepository<Sale>, ISaleWriteRepository
    {
        /// <inheritdoc/>
        public SaleWriteRepository(IWriter writer, IDateTimeOffsetProvider dateTimeOffsetProvider) : base(writer, dateTimeOffsetProvider)
        {
        }
    }
}
