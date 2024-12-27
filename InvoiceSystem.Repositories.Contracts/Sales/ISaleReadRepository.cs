using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Sales;

namespace InvoiceSystem.Repositories.Contracts.Sales
{
    /// <summary>
    /// Читает из таблицы <see cref="Sale"/>s
    /// </summary>
    public interface ISaleReadRepository : IReadRepository<Sale>
    {
        /// <summary>
        /// Получить список продаж по ID накладной
        /// </summary>
        Task<IEnumerable<Sale>> GetAllWithInvoiceId(Guid id, CancellationToken cancellationToken);

    }
}
