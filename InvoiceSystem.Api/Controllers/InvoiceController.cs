using AutoMapper;
using InvoiceSystem.Api.Models.Invoices;
using InvoiceSystem.Api.ResponseAttributes;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Services.Contracts.Models.Invoices;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Api.Controllers
{
    /// <summary>
    /// Контроллер накладных
    /// </summary>
    public class InvoiceController : DBObjectController<AddInvoiceApiModel, InvoiceApiModel, AddInvoiceModel, InvoiceModel, Invoice>
    {
        /// <summary>
        /// Конструтор
        /// </summary>
        public InvoiceController(IMapper mapper, IInvoiceService service, IInvoiceValidationService validationService, ILogger<InvoiceController> logger)
            : base(mapper, service, validationService, logger)
        {
        }

        /// <summary>
        /// Получить накладную по ID
        /// </summary>
        [ProducesType(typeof(InvoiceApiModel))]
        public override async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await base.GetById(id, cancellationToken);
        }

        /// <summary>
        /// Получить все накладные
        /// </summary>
        [ProducesType(typeof(IReadOnlyCollection<InvoiceApiModel>))]
        public override async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return await base.GetAll(cancellationToken);
        }
    }
}
