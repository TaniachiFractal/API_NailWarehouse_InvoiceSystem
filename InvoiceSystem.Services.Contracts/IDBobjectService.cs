﻿using InvoiceSystem.Database.Contracts;
using InvoiceSystem.Database.Contracts.ModelInterfaces;

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
        /// Получить <see cref="DBObject"/> по ID
        /// </summary>
        Task<TObjectModel> GetById(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить <see cref="DBObject"/>
        /// </summary>
        Task<Guid> Add(TAddObjectModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Редактировать <see cref="DBObject"/>
        /// </summary>
        Task Edit(TObjectModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить <see cref="DBObject"/>
        /// </summary>
        Task Delete(Guid id, CancellationToken cancellationToken);
    }
}
