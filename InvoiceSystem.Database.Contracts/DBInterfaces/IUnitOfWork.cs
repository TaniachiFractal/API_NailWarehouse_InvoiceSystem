namespace InvoiceSystem.Database.Contracts.DBInterfaces
{
    /// <summary>
    /// Обеспечивает синхронизацию изменений с БД
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Сохранить изменения
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
