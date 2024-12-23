using FluentValidation;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Repositories.Contracts.Customers;

namespace InvoiceSystem.Services.Models.Invoices
{
    /// <summary>
    /// Валидатор для <see cref="AddInvoiceModel"/>
    /// </summary>
    public class AddInvoiceModelValidator : AbstractValidator<AddInvoiceModel>
    {
        private readonly ICustomerReadRepository customerReadRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public AddInvoiceModelValidator(ICustomerReadRepository customerReadRepository)
        {
            this.customerReadRepository = customerReadRepository;

            RuleForCustomerId();
            RuleForExecutionDate();
        }

        /// <summary>
        /// Правило для ID покупателя
        /// </summary>
        public void RuleForCustomerId()
        {
            RuleFor(x => x.CustomerId)
               .NotNull()
               .NotEmpty()

               .MustAsync(async (x, cancellation) => await CustomerExists(x, cancellation))
               .WithMessage(x => $"Покупателя с ID {x.CustomerId} не существует.")
               ;
        }

        /// <summary>
        /// Правило для даты исполнения
        /// </summary>
        public void RuleForExecutionDate()
        {
            RuleFor(x => x.ExecutionDate)
                .NotNull()
                .NotEmpty()
                ;
        }

        private async Task<bool> CustomerExists(Guid id, CancellationToken cancellation)
        {
            var customer = await customerReadRepository.GetById(id, cancellation);
            return customer != null;
        }

    }
}
