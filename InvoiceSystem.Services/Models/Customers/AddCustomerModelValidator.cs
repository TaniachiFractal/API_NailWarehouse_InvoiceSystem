using FluentValidation;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Models.Configuration;
using InvoiceSystem.Database.Contracts.Repositories;

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
        public AddCustomerModelValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(Cnst.MinLen, Cnst.MaxNameLen)
                ;

            RuleFor(x => x.INN)
                .NotNull()
                .NotEmpty()
                .Length(Cnst.INNLen)
                ;

            RuleFor(x => x.INN)
                .Must(a => long.TryParse(a, out var val) && val > 0).WithMessage($"'INN' должен содержать только цифры")
                ;

            RuleFor(x => x.Address)
                .NotNull()
                .NotEmpty()
                .Length(Cnst.MinLen, Cnst.MaxAddressLen)
                ;
        }
    }
}
