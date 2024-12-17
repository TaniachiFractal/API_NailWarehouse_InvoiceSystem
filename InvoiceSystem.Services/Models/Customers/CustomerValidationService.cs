using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Services.Contracts.Models.Customers;

namespace InvoiceSystem.Services.Models.Customers
{
    /// <inheritdoc cref="ICustomerValidationService"/>
    public class CustomerValidationService
        : DBObjectValidationService
        <CustomerModel, AddCustomerModel, CustomerModelValidator, AddCustomerModelValidator>,
        ICustomerValidationService
    {
    }
}
