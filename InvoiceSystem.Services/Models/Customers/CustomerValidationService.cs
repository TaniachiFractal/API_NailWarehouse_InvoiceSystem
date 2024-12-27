using InvoiceSystem.Models.Customers;
using InvoiceSystem.Repositories.Contracts.Customers;
using InvoiceSystem.Services.Contracts.Models.Customers;

namespace InvoiceSystem.Services.Models.Customers
{
    /// <inheritdoc cref="ICustomerValidationService"/>
    public class CustomerValidationService : DBObjectValidationService, ICustomerValidationService
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CustomerValidationService(ICustomerReadRepository readRepository) : base()
        {
            validators.Add(typeof(AddCustomerModel), new AddCustomerModelValidator(readRepository));
            validators.Add(typeof(CustomerModel), new CustomerModelValidator(readRepository));
        }
    }
}
