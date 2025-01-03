﻿using AutoMapper;
using InvoiceSystem.Api.Models.Sales;
using InvoiceSystem.Api.ResponseAttributes;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Services.Contracts;
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
        [ActivatorUtilitiesConstructor]
        public SaleController(IMapper mapper, ISaleService service, ISaleValidationService validationService, ILogger<SaleController> logger)
            : base(mapper, service, validationService, logger)
        {
        }

        /// <summary>
        /// Конструктор с логгером без привязки к типу и сервисами без конкретных интерфейсов
        /// </summary>
        public SaleController(IMapper mapper, IDBobjectService<AddSaleModel, SaleModel, Sale> service, IDBObjectValidationService validationService, ILogger logger) : base(mapper, service, validationService, logger)
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
