using InvoiceSystem.Models.Customers;
using InvoiceSystem.Services.Contracts.Models;

namespace InvoiceSystem.Services.Models.Customers
{
    /// <summary>
    /// Сервис валидации покупателей
    /// </summary>
    public class CustomerValidationService
        : DBObjectValidationService
        <CustomerModel, AddCustomerModel, CustomerModelValidator, AddCustomerModelValidator>,
        ICustomerValidationService
    {
    }
}
