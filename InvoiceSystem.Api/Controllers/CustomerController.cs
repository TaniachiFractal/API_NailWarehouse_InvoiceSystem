using AutoMapper;
using InvoiceSystem.Api.Models.Customers;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Services.Contracts.Models.Customers;

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
        public CustomerController(IMapper mapper, ICustomerService service, ICustomerValidationService validationService)
            : base(mapper, service, validationService)
        {
        }
    }
}
