using System.Diagnostics.CodeAnalysis;

namespace InvoiceSystem.Database.Contracts.DBInterfaces
{
    /// <summary>
    /// Пишет в БД
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Добавить
        /// </summary>
        void Add<T>([NotNull] T entity) where T : class;

        /// <summary>
        /// Удалить
        /// </summary>
        void Delete<T>([NotNull] T entity) where T : class;

        /// <summary>
        /// Обновить
        /// </summary>
        void Update<T>([NotNull] T entity) where T : class;
    }
}
