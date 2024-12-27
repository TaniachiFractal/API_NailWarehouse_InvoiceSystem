using InvoiceSystem.Database.Contracts;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Contracts.Sales;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Repositories.Sales
{
    /// <inheritdoc cref="ISaleReadRepository"/>
    public class SaleReadRepository : BaseReadRepository<Sale>, ISaleReadRepository
    {
        private readonly IReader reader;

        /// <inheritdoc/>
        public SaleReadRepository(IReader reader) : base(reader)
        {
            this.reader = reader;
        }

        async Task<IEnumerable<Sale>> ISaleReadRepository.GetAllWithInvoiceId(Guid id, CancellationToken cancellationToken)
          => await reader.Read<Sale>()
                  .NotDeleted()
                  .Where(x => x.InvoiceId == id)
                  .ToListAsync(cancellationToken);

    }
}
