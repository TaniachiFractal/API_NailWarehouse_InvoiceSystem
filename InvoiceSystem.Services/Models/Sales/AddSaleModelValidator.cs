using FluentValidation;
using InvoiceSystem.Models.Sales;

namespace InvoiceSystem.Services.Models.Sales
{
    /// <summary>
    /// Валидатор для <see cref="AddSaleModel"/>
    /// </summary>
    public class AddSaleModelValidator : AbstractValidator<AddSaleModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AddSaleModelValidator()
        {
            RuleFor(x => x.ProductId)
                .NotNull()
                .NotEmpty()
                ;

            RuleFor(x => x.InvoiceId)
                .NotNull()
                .NotEmpty()
                ;

            RuleFor(x => x.SoldCount)
                .NotNull()
                .NotEmpty()
                .LessThan(int.MaxValue)
                .GreaterThan(0)
                ;
        }
    }
}
