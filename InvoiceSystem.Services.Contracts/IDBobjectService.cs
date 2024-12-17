using InvoiceSystem.Database.Contracts;
using InvoiceSystem.Database.Contracts.ModelInterfaces;
using InvoiceSystem.Models;

namespace InvoiceSystem.Services.Contracts
{
    /// <summary>
    /// Реализует общие CRUD операции
    /// </summary>
    public interface IDBobjectService<TAddObjectModel, TObjectModel, TObject>
        where TObject : DBObject
        where TObjectModel : IUniqueID, TAddObjectModel
    {
        /// <summary>
        /// Получить все данные таблицы <see cref="DBObject"/>
        /// </summary>
        Task<IReadOnlyCollection<TObjectModel>> GetAll(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <typeparamref name="TObject" /> по ID
        /// </summary>
        Task<TObjectModel> GetById(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить <typeparamref name="TObject" />
        /// </summary>
        Task<Guid> Add(TAddObjectModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Редактировать <typeparamref name="TObject" />
        /// </summary>
        Task Edit(TObjectModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить <typeparamref name="TObject" />
        /// </summary>
        Task Delete(Guid id, CancellationToken cancellationToken);
    }
}
