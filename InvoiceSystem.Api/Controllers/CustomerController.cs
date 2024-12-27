using AutoMapper;
using InvoiceSystem.Api.Models.Customers;
using InvoiceSystem.Api.ResponseAttributes;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Services.Contracts;
using InvoiceSystem.Services.Contracts.Models.Customers;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Api.Controllers
{
    /// <summary>
    /// Контроллер покупателей
    /// </summary>
    public class CustomerController : DBObjectController<AddCustomerApiModel, CustomerApiModel, AddCustomerModel, CustomerModel, Customer>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CustomerController(IMapper mapper, ICustomerService service, ICustomerValidationService validationService, ILogger<CustomerController> logger)
            : base(mapper, service, validationService, logger)
        {
        }

        /// <summary>
        /// Конструктор с логгером без привязки к типу и сервисами без конкретных интерфейсов
        /// </summary>
        public CustomerController(IMapper mapper, IDBobjectService<AddCustomerModel, CustomerModel, Customer> service, IDBObjectValidationService validationService, ILogger logger)
            : base(mapper, service, validationService, logger)
        {
        }

        /// <summary>
        /// Получить покупателя по ID
        /// </summary>
        [ProducesType(typeof(CustomerApiModel))]
        public override async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await base.GetById(id, cancellationToken);
        }

        /// <summary>
        /// Получить всех покупателей
        /// </summary>
        [ProducesType(typeof(IReadOnlyCollection<CustomerApiModel>))]
        public override async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return await base.GetAll(cancellationToken);
        }
    }
}
