using AutoMapper;
using InvoiceSystem.Api.Models;
using InvoiceSystem.Api.ResponseAttributes;
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

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainController(IMainService mainService, IMapper mapper)
        {
            this.mainService = mainService;
            this.mapper = mapper;
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
            return Ok(result);
        }

        /// <summary>
        /// Получить данные всех таблиц в виде SQL запросов
        /// </summary>
        [HttpGet]
        [ProducesType(typeof(string))]
        public async Task<IActionResult> GetAllTablesAsSQLQueries(CancellationToken cancellationToken)
        {
            var result = await mainService.GetAllTablesAsSQLQueries(cancellationToken);
            return Ok(result);
        }
    }
}
