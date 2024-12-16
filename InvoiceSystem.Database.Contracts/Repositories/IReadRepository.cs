namespace InvoiceSystem.Database.Contracts.Repositories
{
    /// <summary>
    /// Стандартные методы чтения
    /// </summary>
    public interface IReadRepository<T> where T : class
    {
#nullable enable
        /// <summary>
        /// Получить по ID
        /// </summary>
        Task<T?> GetById(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить всех
        /// </summary>
        Task<IReadOnlyCollection<T>> GetAll(CancellationToken cancellationToken);
#nullable disable
    }
}
