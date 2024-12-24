using FluentValidation;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Repositories.Contracts.Customers;

namespace InvoiceSystem.Services.Models.Customers
{
    /// <summary>
    /// Валидатор для <see cref="AddCustomerModel"/>
    /// </summary>
    public class AddCustomerModelValidator : AbstractValidator<AddCustomerModel>
    {
        private readonly ICustomerReadRepository customerReadRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public AddCustomerModelValidator(ICustomerReadRepository customerReadRepository)
        {
            Include(new BaseCustomerModelValidator());

            this.customerReadRepository = customerReadRepository;
            RuleFor(x => x.INN)
               .MustAsync(async (x, cancellation) => await INNIsUniqueAsync(x, cancellation))
               .WithMessage(x => $"Покупатель с ИНН {x.INN} уже существует.")
               ;
        }

        private async Task<bool> INNIsUniqueAsync(
            string inn,
            CancellationToken cancellationToken)
        {
            var customers = await customerReadRepository.GetAll(cancellationToken);
            var customer = customers.FirstOrDefault(x => x.INN == inn);
            return customer == null;
        }
    }
}
