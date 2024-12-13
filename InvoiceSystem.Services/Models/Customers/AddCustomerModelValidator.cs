using FluentValidation;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Models.Configuration;

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
                .NotEmpty()
                .Length(Cnst.MinLen, Cnst.MaxNameLen)
                ;

            RuleFor(x => x.INN)
                .NotEmpty()
                .Length(Cnst.INNLen)
                ;

            RuleFor(x => x.Address)
                .NotEmpty()
                .Length(Cnst.MinLen, Cnst.MaxAddressLen)
                ;
        }
    }
}
