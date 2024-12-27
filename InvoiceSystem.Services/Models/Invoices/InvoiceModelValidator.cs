using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Repositories.Contracts.Customers;

namespace InvoiceSystem.Services.Models.Invoices
{
    /// <summary>
    /// Валидатор для <see cref="InvoiceModel"/>
    /// </summary>
    public class InvoiceModelValidator : UniqueIdValidator<InvoiceModel, AddInvoiceModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public InvoiceModelValidator(ICustomerReadRepository readRepository) : base(new AddInvoiceModelValidator(readRepository))
        {
        }
    }
}
