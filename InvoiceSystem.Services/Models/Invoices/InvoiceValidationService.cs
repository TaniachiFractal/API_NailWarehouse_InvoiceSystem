using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Repositories.Contracts.Customers;
using InvoiceSystem.Services.Contracts.Models.Invoices;

namespace InvoiceSystem.Services.Models.Invoices
{
    /// <inheritdoc cref="IInvoiceValidationService"/>
    public class InvoiceValidationService : DBObjectValidationService, IInvoiceValidationService
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public InvoiceValidationService(ICustomerReadRepository customerReadRepository) : base()
        {
            validators.Add(typeof(AddInvoiceModel), new AddInvoiceModelValidator(customerReadRepository));
            validators.Add(typeof(InvoiceModel), new InvoiceModelValidator(customerReadRepository));
        }
    }
}
