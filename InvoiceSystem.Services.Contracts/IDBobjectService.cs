namespace InvoiceSystem.Services.Contracts
{
    /// <summary>
    /// Реализует общие CRUD операции
    /// </summary>
    public interface IDBobjectService
    {
        /// <summary>
        /// Получить все данные таблицы модели
        /// </summary>
        Task<IReadOnlyCollection<TModel>> GetAll<TModel>(CancellationToken cancellationToken);

        /// <summary>
        /// Получить модель по ID
        /// </summary>
        Task<Tmodel> GetById<Tmodel>(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить модель
        /// </summary>
        Task<Guid> Add<TModel>(TModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Редактировать модель
        /// </summary>
        Task Edit<TModel>(TModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить модель
        /// </summary>
        Task Delete(Guid id, CancellationToken cancellationToken);
    }
}
