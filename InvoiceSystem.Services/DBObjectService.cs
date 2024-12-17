using AutoMapper;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Database.Contracts.ModelInterfaces;
using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models;
using InvoiceSystem.Services.Contracts;
using InvoiceSystem.Services.Exceptions;

namespace InvoiceSystem.Services
{
    /// <summary>
    /// Стандартный сервис
    /// </summary>
    public abstract class DBObjectService<TAddObjectModel, TObjectModel, TObject> : IDBobjectService<TAddObjectModel, TObjectModel, TObject>
        where TObject : DBObject
        where TObjectModel : IUniqueID, TAddObjectModel
    {
        private readonly IMapper mapper;
        private readonly IReadRepository<TObject> readRepository;
        private readonly IWriteRepository<TObject> writeRepository;
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DBObjectService(
            IMapper mapper,
            IReadRepository<TObject> readRepository,
            IWriteRepository<TObject> writeRepository,
            IUnitOfWork unitOfWork
            )
        {
            this.mapper = mapper;
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <inheritdoc/>
        public async Task<Guid> Add(TAddObjectModel model, CancellationToken cancellationToken)
        {
            var item = mapper.Map<TObject>(model);
            writeRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return item.Id;
        }

        /// <inheritdoc/>
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var item = await readRepository.GetById(id, cancellationToken) ?? throw new NotFoundException(id, nameof(TObject));
            writeRepository.Delete(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task Edit(TObjectModel model, CancellationToken cancellationToken)
        {
            var _ = await readRepository.GetById(model.Id, cancellationToken) ?? throw new NotFoundException(model.Id, nameof(TObject));
            var result = mapper.Map<TObject>(model);
            writeRepository.Update(result);
            await unitOfWork.SaveChangesAsync(cancellationToken);

        }

        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<TObjectModel>> GetAll(CancellationToken cancellationToken)
        {
            var items = await readRepository.GetAll(cancellationToken);
            var result = mapper.Map<IReadOnlyCollection<TObjectModel>>(items);
            return result;
        }

        /// <inheritdoc/>
        public async Task<TObjectModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await readRepository.GetById(id, cancellationToken);
            var result = mapper.Map<TObjectModel>(item);
            return item == null ? throw new NotFoundException(id, nameof(TObject)) : result;
        }
    }
}
