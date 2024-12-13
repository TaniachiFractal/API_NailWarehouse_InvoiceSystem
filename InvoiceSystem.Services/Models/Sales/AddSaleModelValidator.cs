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
                .NotEmpty()
                ;

            RuleFor(x => x.InvoiceId)
                .NotEmpty()
                ;

            RuleFor(x => x.SoldCount)
                .NotEmpty()
                .LessThan(int.MaxValue)
                .GreaterThan(0)
                ;
        }
    }
}
