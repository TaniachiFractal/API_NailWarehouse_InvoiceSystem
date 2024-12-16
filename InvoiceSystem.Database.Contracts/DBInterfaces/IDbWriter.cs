using System.Diagnostics.CodeAnalysis;

namespace InvoiceSystem.Database.Contracts.DBInterfaces
{
    /// <summary>
    /// Пишет данные в БД
    /// </summary>
    public interface IDbWriter<in TEntity> where TEntity : class
    {
        /// <summary>
        /// Добавить
        /// </summary>
        void Add([NotNull] TEntity entity);

        /// <summary>
        /// Удалить
        /// </summary>
        void Delete([NotNull] TEntity entity);

        /// <summary>
        /// Обновить
        /// </summary>
        void Update([NotNull] TEntity entity);
    }
}
