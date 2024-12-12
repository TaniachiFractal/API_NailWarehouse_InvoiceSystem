using AutoMapper;
using InvoiceSystem.Database;
using InvoiceSystem.Database.Contracts;
using InvoiceSystem.Models;
using InvoiceSystem.Services.Contracts;
using InvoiceSystem.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Services.Models
{
    /// <summary>
    /// Стандартный сервис
    /// </summary>
    /// <typeparam name="TAddObjectModel">Модель добавления</typeparam>
    /// <typeparam name="TObjectModel">Модель чтения с ID</typeparam>
    /// <typeparam name="TObject">Сам класс из которого состоит таблица</typeparam>
    public class DBObjectService<TAddObjectModel, TObjectModel, TObject> : IDBobjectService<TAddObjectModel, TObjectModel, TObject>
        where TObject : DBObject
        where TObjectModel : IUniqueID
    {
        private readonly InvcSysDBContext dbContext;
        private readonly IMapper mapper;
        private readonly DbSet<TObject> dbSet;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DBObjectService(InvcSysDBContext dbContext, DbSet<TObject> dbSet, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.dbSet = dbSet;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<Guid> Add(TAddObjectModel model, CancellationToken cancellationToken)
        {
            var item = mapper.Map<TObject>(model);
            item.CreatedDate = DateTimeOffset.Now;
            dbSet.Add(item);
            await dbContext.SaveChangesAsync(cancellationToken);
            return item.Id;
        }

        /// <inheritdoc/>
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await
                dbSet.FirstOrDefaultAsync
                (x => x.Id == id && x.DeletedDate == null, cancellationToken)
                ?? throw new NotFoundException(id, nameof(TObject));
            result.DeletedDate = DateTimeOffset.Now;
            dbSet.Update(result);
            await dbContext.SaveChangesAsync(cancellationToken);

        }

        /// <inheritdoc/>
        public Task Edit(TAddObjectModel model, CancellationToken cancellationToken) => throw new NotImplementedException();

        /// <inheritdoc/>
        public Task<IReadOnlyCollection<TObjectModel>> GetAll(CancellationToken cancellationToken) => throw new NotImplementedException();

        /// <inheritdoc/>
        public Task<TObjectModel> GetById(Guid id, CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
