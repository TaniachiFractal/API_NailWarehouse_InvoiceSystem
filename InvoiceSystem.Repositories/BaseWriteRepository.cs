using System.Diagnostics.CodeAnalysis;
using InvoiceSystem.Common;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Database.Contracts.ModelInterfaces;
using InvoiceSystem.Database.Contracts.Repositories;
using Microsoft.Extensions.Logging;

namespace InvoiceSystem.Repositories
{
    /// <summary>
    /// Стандартный репозиторий записи в БД
    /// </summary>
    public abstract class BaseWriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly IWriter writer;
        private readonly IDateTimeOffsetProvider dateTimeOffsetProvider;
        private readonly ILogger logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        protected BaseWriteRepository(IWriter writer, IDateTimeOffsetProvider dateTimeOffsetProvider, ILogger logger)
        {
            this.writer = writer;
            this.dateTimeOffsetProvider = dateTimeOffsetProvider;
            this.logger = logger;
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

            LogInfo(entity, "Added");
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

            LogInfo(entity, "Deleted");
        }

        /// <inheritdoc/>
        public void Update([NotNull] T entity)
        {
            AuditForUpdate(entity);
            writer.Update(entity);

            LogInfo(entity, "Updated");
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

        private void LogInfo(T entity, string action)
        {
            logger.LogInformation("@@@@ {ACTION} entity {ENTITY} with data {@DATA}", action, entity.GetType().Name, entity);
        }
    }
}
