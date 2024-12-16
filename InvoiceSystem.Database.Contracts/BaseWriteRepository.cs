using System.Diagnostics.CodeAnalysis;
using InvoiceSystem.Common;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Database.Contracts.ModelInterfaces;

namespace InvoiceSystem.Database.Contracts
{
    /// <summary>
    /// Стандартный репозиторий записи в БД
    /// </summary>
    public abstract class BaseWriteRepository<T> : IDbWriter<T> where T : DBObject
    {
        private readonly IWriter writer;
        private readonly IDateTimeOffsetProvider dateTimeOffsetProvider;

        /// <summary>
        /// Конструктор
        /// </summary>
        protected BaseWriteRepository(IWriter writer, IDateTimeOffsetProvider dateTimeOffsetProvider)
        {
            this.writer = writer;
            this.dateTimeOffsetProvider = dateTimeOffsetProvider;
        }

        /// <inheritdoc/>
        public void Add([NotNull] T entity)
        {
            if (entity is IUniqueID uniqueId && uniqueId.Id == default)
            {
                uniqueId.Id = Guid.NewGuid();
            }
            AuditForCreate(entity);
            writer.Add(entity);
        }

        /// <inheritdoc/>
        public void Delete([NotNull] T entity)
        {
            AuditForUpdate(entity);
            if (entity is ISoftDeleted)
            {
                AuditForDelete(entity);
                writer.Update(entity);
            }
            else
            {
                writer.Delete(entity);
            }
        }

        /// <inheritdoc/>
        public void Update([NotNull] T entity)
        {
            AuditForUpdate(entity);
            writer.Update(entity);
        }

        private void AuditForCreate([NotNull] T entity)
        {
            if (entity is IAuditable auditable)
            {
                auditable.CreatedDate = dateTimeOffsetProvider.UtcNow;
                auditable.UpdatedDate = dateTimeOffsetProvider.UtcNow;
            }
        }

        private void AuditForUpdate([NotNull] T entity)
        {
            if (entity is IAuditable auditable)
            {
                auditable.UpdatedDate = dateTimeOffsetProvider.UtcNow;
            }
        }

        private void AuditForDelete([NotNull] T entity)
        {
            if (entity is ISoftDeleted softDeleted)
            {
                softDeleted.DeletedDate = dateTimeOffsetProvider.UtcNow;
            }
        }
    }
}
