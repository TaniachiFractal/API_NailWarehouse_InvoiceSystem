using FluentValidation;
using InvoiceSystem.Common;
using InvoiceSystem.Models.Configuration;
using InvoiceSystem.Models.Customers;

namespace InvoiceSystem.Services.Models.Customers
{
    /// <summary>
    /// Валидатор покупателей с общими правиламм для всех валидаторов покупателей
    /// </summary>
    public class BaseCustomerModelValidator : AbstractValidator<AddCustomerModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public BaseCustomerModelValidator()
        {
            RuleForName();
            RuleForINN();
            RuleForAddress();
        }

        private void RuleForINN()
        {
            RuleFor(x => x.INN)
               .NotNull()
               .NotEmpty()
               .Length(Cnst.INNLen)

               .Must(x => long.TryParse(x, out var val) && val > -1)
               .WithMessage($"ИНН должен содержать только цифры");
        }

        private void RuleForName()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(Cnst.MinLen, Cnst.MaxNameLen);
        }

        private void RuleForAddress()
        {
            RuleFor(x => x.Address)
                .NotNull()
                .NotEmpty()
                .Length(Cnst.MinLen, Cnst.MaxAddressLen)
                ;
        }
    }
}
