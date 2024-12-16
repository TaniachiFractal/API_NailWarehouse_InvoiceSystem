using AutoMapper;
using InvoiceSystem.Database;
using InvoiceSystem.Database.Contracts;
using InvoiceSystem.Database.Contracts.ModelInterfaces;
using InvoiceSystem.Services.Contracts;
using InvoiceSystem.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Services
{
    /// <summary>
    /// Стандартный сервис
    /// </summary>
    public class DBObjectService<TAddObjectModel, TObjectModel, TObject> : IDBobjectService<TAddObjectModel, TObjectModel, TObject>
        where TObject : DBObject
        where TObjectModel : IUniqueID, TAddObjectModel
    {
        private readonly InvcSysDBContext dbContext;
        private readonly IMapper mapper;
        private readonly DbSet<TObject> table;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DBObjectService(InvcSysDBContext dbContext, DbSet<TObject> table, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.table = table;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<Guid> Add(TAddObjectModel model, CancellationToken cancellationToken)
        {
            var item = mapper.Map<TObject>(model);
            table.Add(item);
            await dbContext.SaveChangesAsync(cancellationToken);
            return item.Id;
        }

        /// <inheritdoc/>
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await
                table.FirstOrDefaultAsync
                (x => x.Id == id && x.DeletedDate == null, cancellationToken)
                ?? throw new NotFoundException(id, nameof(TObject));

            foreach (var fieldInfo in result.GetType().GetFields())
            { fieldInfo.SetValue(result, null); }

            result.DeletedDate = DateTimeOffset.Now;
            table.Update(result);
            await dbContext.SaveChangesAsync(cancellationToken);

        }

        /// <inheritdoc/>
        public async Task Edit(TObjectModel model, CancellationToken cancellationToken)
        {
            var result = await
                table.FirstOrDefaultAsync
                (x => x.Id == model.Id && x.DeletedDate == null, cancellationToken)
                ?? throw new NotFoundException(model.Id, nameof(TObject));

            result = mapper.Map<TObject>(model);
            result.UpdatedDate = DateTimeOffset.Now;

            table.Update(result);
            await dbContext.SaveChangesAsync(cancellationToken);

        }

        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<TObjectModel>> GetAll(CancellationToken cancellationToken)
        {
            var items = await table
              .Where(x => x.DeletedDate == null)
              .AsNoTracking()
              .ToListAsync(cancellationToken);
            var result = mapper.Map<IReadOnlyCollection<TObjectModel>>(items);
            return result;

        }

        /// <inheritdoc/>
        public async Task<TObjectModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await table
               .Where(x => x.Id == id && x.DeletedDate == null)
               .AsNoTracking()
               .FirstOrDefaultAsync(cancellationToken);
            var result = mapper.Map<TObjectModel>(item);
            return item == null
                ? throw new NotFoundException(id, nameof(TObject)) : result;
        }
    }
}
