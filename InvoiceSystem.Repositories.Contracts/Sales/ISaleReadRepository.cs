using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Sales;

namespace InvoiceSystem.Repositories.Contracts.Sales
{
    /// <summary>
    /// Читает из таблицы <see cref="Sale"/>s
    /// </summary>
    public interface ISaleReadRepository : IReadRepository<Sale>
    {
    }
}
