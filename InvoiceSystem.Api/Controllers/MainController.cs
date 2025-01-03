﻿using AutoMapper;
using InvoiceSystem.Api.Models;
using InvoiceSystem.Api.ResponseAttributes;
using InvoiceSystem.Common;
using InvoiceSystem.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Api.Controllers
{
    /// <summary>
    /// Главный контроллер
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        private readonly IMainService mainService;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        [ActivatorUtilitiesConstructor]
        public MainController(IMainService mainService, IMapper mapper, ILogger<MainController> logger)
        {
            this.mainService = mainService;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Конструктор без типизированного логгера
        /// </summary>
        public MainController(IMainService mainService, IMapper mapper, ILogger logger)
        {
            this.mainService = mainService;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Получить все данные накладной
        /// </summary>
        [HttpGet("{InvoiceId:guid}")]
        [ProducesNotFound()]
        [ProducesType(typeof(FullInvoiceInfoApiModel))]
        public async Task<IActionResult> GetById(Guid InvoiceId, CancellationToken cancellationToken)
        {
            var item = await mainService.GetFullInvoiceInfo(InvoiceId, cancellationToken);
            var result = mapper.Map<FullInvoiceInfoApiModel>(item);
            LogAnswer(result);
            return Ok(result);
        }

        private void LogAnswer(object result)
        => Com.LogControllerAnswer(logger, GetType(), result);
    }
}
