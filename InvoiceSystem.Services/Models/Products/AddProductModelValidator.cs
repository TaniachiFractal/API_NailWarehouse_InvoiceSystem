using FluentValidation;
using InvoiceSystem.Common;
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
            RuleForName();
            RuleForPrice();
        }

        /// <summary>
        /// Правило для названия
        /// </summary>
        public void RuleForName()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(Com.MinLen, Com.MaxNameLen);
        }

        /// <summary>
        /// Правило для цены
        /// </summary>
        public void RuleForPrice()
        {
            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty()
                .LessThan(decimal.MaxValue)
                .GreaterThanOrEqualTo(0)
                ;
        }
    }
}
