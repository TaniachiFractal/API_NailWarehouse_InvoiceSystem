using FluentValidation;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Repositories.Contracts.Customers;

namespace InvoiceSystem.Services.Models.Customers
{
    /// <summary>
    /// Валидатор для <see cref="CustomerModel"/>
    /// </summary>
    public class CustomerModelValidator : UniqueIdValidator<CustomerModel, AddCustomerModel>
    {
        private readonly ICustomerReadRepository customerReadRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public CustomerModelValidator(ICustomerReadRepository customerReadRepository) : base()
        {
            Include(new BaseCustomerModelValidator());

            this.customerReadRepository = customerReadRepository;
            RuleFor(x => x.INN)
               .MustAsync(async (x, inn, cancellation) => await INNIsUniqueAsync(inn, x.Id, cancellation))
               .WithMessage(x => $"Покупатель с ИНН {x.INN} уже существует.")
               ;
        }

        private async Task<bool> INNIsUniqueAsync(
            string inn,
            Guid id,
            CancellationToken cancellationToken)
        {
            var customers = await customerReadRepository.GetAll(cancellationToken);
            var customer = customers.FirstOrDefault(x => x.INN == inn && x.Id != id);
            return customer == null;
        }
    }
}
