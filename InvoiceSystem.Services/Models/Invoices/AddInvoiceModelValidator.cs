using FluentValidation;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Models.Configuration;
using InvoiceSystem.Models.Invoices;

namespace InvoiceSystem.Services.Models.Invoices
{
    /// <summary>
    /// Валидатор для <see cref="AddInvoiceModel"/>
    /// </summary>
    public class AddInvoiceModelValidator : AbstractValidator<AddInvoiceModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AddInvoiceModelValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                ;

            RuleFor(x => x.ExecutionDate)
                .NotEmpty()
                ;
        }
    }
}
