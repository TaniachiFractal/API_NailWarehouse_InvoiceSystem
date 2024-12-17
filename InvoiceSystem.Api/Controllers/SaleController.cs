using AutoMapper;
using InvoiceSystem.Api.Models.Sales;
using InvoiceSystem.Api.ResponseAttributes;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Services.Contracts.Models.Sales;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Api.Controllers
{
    /// <summary>
    /// Контроллер продаж
    /// </summary>
    public class SaleController : DBObjectController<AddSaleApiModel, SaleApiModel, AddSaleModel, SaleModel, Sale>
    {
        /// <summary>
        /// Конструтор
        /// </summary>
        public SaleController(IMapper mapper, ISaleService service, ISaleValidationService validationService)
            : base(mapper, service, validationService)
        {
        }

        /// <summary>
        /// Получить продажу по ID
        /// </summary>
        [ProducesType(typeof(SaleApiModel))]
        public override async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await base.GetById(id, cancellationToken);
        }

        /// <summary>
        /// Получить все продажи
        /// </summary>
        [ProducesType(typeof(IReadOnlyCollection<SaleApiModel>))]
        public override async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return await base.GetAll(cancellationToken);
        }
    }
}
