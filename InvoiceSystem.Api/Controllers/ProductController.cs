﻿using AutoMapper;
using InvoiceSystem.Api.Models.Products;
using InvoiceSystem.Api.ResponseAttributes;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Services.Contracts;
using InvoiceSystem.Services.Contracts.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Api.Controllers
{
    /// <summary>
    /// Контроллер товаров
    /// </summary>
    public class ProductController : DBObjectController<AddProductApiModel, ProductApiModel, AddProductModel, ProductModel, Product>
    {
        /// <summary>
        /// Конструтор
        /// </summary>
        [ActivatorUtilitiesConstructor]
        public ProductController(IMapper mapper, IProductService service, IProductValidationService validationService, ILogger<ProductController> logger)
            : base(mapper, service, validationService, logger)
        {
        }

        /// <summary>
        /// Конструктор с логгером без привязки к типу и сервисами без конкретных интерфейсов
        /// </summary>
        public ProductController(IMapper mapper, IDBobjectService<AddProductModel, ProductModel, Product> service, IDBObjectValidationService validationService, ILogger logger) : base(mapper, service, validationService, logger)
        {
        }

        /// <summary>
        /// Получить товар по ID
        /// </summary>
        [ProducesType(typeof(ProductApiModel))]
        public override async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await base.GetById(id, cancellationToken);
        }

        /// <summary>
        /// Получить все товары
        /// </summary>
        [ProducesType(typeof(IReadOnlyCollection<ProductApiModel>))]
        public override async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return await base.GetAll(cancellationToken);
        }
    }
}
