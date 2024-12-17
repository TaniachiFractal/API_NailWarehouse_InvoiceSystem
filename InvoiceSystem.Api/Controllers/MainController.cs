using InvoiceSystem.Api.Models;
using InvoiceSystem.Api.ResponseAttributes;
using InvoiceSystem.Services.Contracts.Models.Customers;
using InvoiceSystem.Services.Contracts.Models.Invoices;
using InvoiceSystem.Services.Contracts.Models.Products;
using InvoiceSystem.Services.Contracts.Models.Sales;
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
        private ICustomerService customerService;
        private IInvoiceService invoiceService;
        private IProductService productService;
        private ISaleService saleService;

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainController(ICustomerService customerService, IInvoiceService invoiceService, IProductService productService, ISaleService saleService)
        {
            this.customerService = customerService;
            this.invoiceService = invoiceService;
            this.productService = productService;
            this.saleService = saleService;
        }

        /// <summary>
        /// Получить все данные накладной
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesNotFound()]
        [ProducesType(typeof(FullInvoiceInfoModel))]
        public virtual async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var invoice = await invoiceService.GetById(id, cancellationToken);
            var 
            var item = await service.GetById(id, cancellationToken);
            var result = mapper.Map<TApiModel>(item);
            return Ok(result);
        }
    }
}
