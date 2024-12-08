using InvoiceSystem.Database.Contracts;

namespace InvoiceSystem.Models
{
    /// <summary>
    /// Объект, из которого можно создать таблицу в БД
    /// </summary>
    public abstract class DBObject : IUniqueID, IAuditable, ISoftDeleted
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }

        /// <inheritdoc/>
        public DateTimeOffset CreatedDate { get; set; }

        /// <inheritdoc/>
        public DateTimeOffset? UpdatedDate { get; set; }

        /// <inheritdoc/>
        public DateTimeOffset? DeletedDate { get; set; }
    }
}
