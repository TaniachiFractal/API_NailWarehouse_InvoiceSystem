using FluentValidation;
using InvoiceSystem.Database.Contracts.Repositories;
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
                .NotNull()
                .NotEmpty()
                ;

            RuleFor(x => x.ExecutionDate)
                .NotNull()
                .NotEmpty()
                ;
        }
    }
}
