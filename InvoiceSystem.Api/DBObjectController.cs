using AutoMapper;
using InvoiceSystem.Api.ResponseAttributes;
using InvoiceSystem.Database.Contracts.ModelInterfaces;
using InvoiceSystem.Models;
using InvoiceSystem.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Api
{
    /// <summary>
    /// Контроллер со стандартными методами
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public abstract class DBObjectController<TAddApiModel, TApiModel, TAddObjectModel, TObjectModel, TObject> : ControllerBase
        where TApiModel : TAddApiModel, IUniqueID
        where TObject : DBObject
        where TObjectModel : IUniqueID, TAddObjectModel
    {
        private readonly IMapper mapper;
        private readonly IDBobjectService<TAddObjectModel, TObjectModel, TObject> service;
        private readonly IDBObjectValidationService validationService;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DBObjectController(
            IMapper mapper,
            IDBobjectService<TAddObjectModel, TObjectModel, TObject> service,
            IDBObjectValidationService validationService)
        {
            this.mapper = mapper;
            this.service = service;
            this.validationService = validationService;
        }

        /// <summary>
        /// Получить по ID
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesNotFound()]
        public virtual async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await service.GetById(id, cancellationToken);
            var result = mapper.Map<TApiModel>(item);
            return Ok(result);
        }

        /// <summary>
        /// Получить список
        /// </summary>
        [HttpGet]
        public virtual async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var items = await service.GetAll(cancellationToken);
            var result = mapper.Map<IReadOnlyCollection<TApiModel>>(items);
            return Ok(result);
        }

        /// <summary>
        /// Добавить 
        /// </summary>
        [HttpPost]
        [ProducesValidationError()]
        [ProducesNoContent()]
        public async Task<IActionResult> Add(TAddApiModel request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<TAddObjectModel>(request);
            await validationService.Validate(model, cancellationToken);
            await service.Add(model, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Редактировать 
        /// </summary>
        [HttpPut("{id:guid}")]
        [ProducesValidationError()]
        [ProducesNotFound()]
        [ProducesNoContent()]
        public async Task<IActionResult> Edit
            ([FromRoute] Guid id, [FromBody] TAddApiModel request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<TObjectModel>(request);
            model.Id = id;
            await validationService.Validate(model, cancellationToken);
            await service.Edit(model, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Удалить 
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesNotFound()]
        [ProducesNoContent()]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await service.Delete(id, cancellationToken);
            return NoContent();
        }

    }
}
