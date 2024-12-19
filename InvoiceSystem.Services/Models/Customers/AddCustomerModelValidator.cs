using FluentValidation;
using InvoiceSystem.Models.Configuration;
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
            this.customerReadRepository = customerReadRepository;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(Cnst.MinLen, Cnst.MaxNameLen)

                .MustAsync(async (x, cancellation) => await NameIsUniqueAsync(x, cancellation))
                .WithMessage(x => $"Покупатель с названием {x} уже существует.")
                ;

            RuleFor(x => x.INN)
                .NotNull()
                .NotEmpty()
                .Length(Cnst.INNLen)

                .Must(x => long.TryParse(x, out var val) && val > 0)
                .WithMessage($"ИНН должен содержать только цифры")

                .MustAsync(async (x, cancellation) => await INNIsUniqueAsync(x, cancellation))
                .WithMessage(x => $"Покупатель с ИНН {x} уже существует.")
                ;

            RuleFor(x => x.Address)
                .NotNull()
                .NotEmpty()
                .Length(Cnst.MinLen, Cnst.MaxAddressLen)
                ;
        }

        private async Task<bool> NameIsUniqueAsync(string name, CancellationToken cancellationToken)
        {
            var customers = await customerReadRepository.GetAll(cancellationToken);
            var customer = customers.FirstOrDefault(x => x.Name == name);
            return customer == null;
        }

        private async Task<bool> INNIsUniqueAsync(string inn, CancellationToken cancellationToken)
        {
            var customers = await customerReadRepository.GetAll(cancellationToken);
            var customer = customers.FirstOrDefault(x => x.INN == inn);
            return customer == null;
        }
    }
}
