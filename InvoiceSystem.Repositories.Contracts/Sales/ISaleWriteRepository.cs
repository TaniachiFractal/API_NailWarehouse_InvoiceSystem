using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Sales;

namespace InvoiceSystem.Repositories.Contracts.Sales
{
    /// <summary>
    /// Пишет в таблицу <see cref="Sale"/>s
    /// </summary>
    public interface ISaleWriteRepository : IWriteRepository<Sale>
    {
    }
}
