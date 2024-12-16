using InvoiceSystem.Database.Contracts;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Database.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Repositories
{
    /// <summary>
    /// Стандартный репозиторий чтения
    /// </summary>
    public class BaseReadRepository<T> : IReadRepository<T> where T : DBObject
    {
        private readonly IReader reader;

        /// <summary>
        /// Конструктор
        /// </summary>
        public BaseReadRepository(IReader reader)
        {
            this.reader = reader;
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<T>> GetAll(CancellationToken cancellationToken)
             => await reader.Read<T>()
                    .NotDeleted()
                    .ToListAsync(cancellationToken);

        /// <inheritdoc/>
        public async Task<T?> GetById(Guid id, CancellationToken cancellationToken)
             => await reader.Read<T>()
                    .NotDeleted()
                    .WithId(id)
                    .FirstOrDefaultAsync(cancellationToken);

    }
}
