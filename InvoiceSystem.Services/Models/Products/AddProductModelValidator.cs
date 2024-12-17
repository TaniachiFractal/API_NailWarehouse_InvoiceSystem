using FluentValidation;
using InvoiceSystem.Models.Configuration;
using InvoiceSystem.Models.Products;

namespace InvoiceSystem.Services.Models.Products
{
    /// <summary>
    /// Валидатор для <see cref="AddProductModel"/>
    /// </summary>
    public class AddProductModelValidator : AbstractValidator<AddProductModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AddProductModelValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(Cnst.MinLen, Cnst.MaxNameLen)
                ;

            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty()
                .LessThan(decimal.MaxValue)
                .GreaterThan(0)
                ;
        }
    }
}
