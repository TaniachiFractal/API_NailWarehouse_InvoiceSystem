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
        [HttpGet("{id:guid}")]
        [ProducesNotFound()]
        [ProducesType(typeof(FullInvoiceInfoApiModel))]
        public virtual async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await mainService.GetFullInvoiceInfo(id, cancellationToken);
            var result = mapper.Map<FullInvoiceInfoApiModel>(item);
            return Ok(result);
        }
    }
}
