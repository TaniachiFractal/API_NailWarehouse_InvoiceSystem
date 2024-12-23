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
        /// <summary>
        /// Конструктор
        /// </summary>
        public AddCustomerModelValidator(ICustomerReadRepository customerReadRepository)
        {
            RuleForName(this);
            RuleForINN(this, customerReadRepository);
            RuleForAddress(this);
        }

        /// <summary>
        /// Задать правила для ИНН
        /// </summary>
        public static void RuleForINN<T>(
            AbstractValidator<T> validator,
            ICustomerReadRepository customerReadRepository)
            where T : AddCustomerModel
        {
            validator
               .RuleFor(x => x.INN)
               .NotNull()
               .NotEmpty()
               .Length(Cnst.INNLen)

               .Must(x => long.TryParse(x, out var val) && val > 0)
               .WithMessage($"ИНН должен содержать только цифры")

               .MustAsync(async (x, cancellation) => await INNIsUniqueAsync(x, cancellation, customerReadRepository))
               .WithMessage(x => $"Покупатель с ИНН {x.INN} уже существует.")
               ;
        }

        /// <summary>
        /// Задать правила для названия
        /// </summary>
        public static void RuleForName<T>(AbstractValidator<T> validator) where T : AddCustomerModel
        {
            validator
                .RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(Cnst.MinLen, Cnst.MaxNameLen);
        }

        /// <summary>
        /// Задать правила для адреса
        /// </summary>
        public static void RuleForAddress<T>(AbstractValidator<T> validator) where T : AddCustomerModel
        {
            validator
                .RuleFor(x => x.Address)
                .NotNull()
                .NotEmpty()
                .Length(Cnst.MinLen, Cnst.MaxAddressLen)
                ;
        }

        private static async Task<bool> INNIsUniqueAsync(
            string inn,
            CancellationToken cancellationToken,
            ICustomerReadRepository customerReadRepository)
        {
            var customers = await customerReadRepository.GetAll(cancellationToken);
            var customer = customers.FirstOrDefault(x => x.INN == inn);
            return customer == null;
        }
    }
}
