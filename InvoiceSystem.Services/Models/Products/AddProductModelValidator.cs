using FluentValidation;
using InvoiceSystem.Models.Configuration;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Repositories.Contracts.Products;

namespace InvoiceSystem.Services.Models.Products
{
    /// <summary>
    /// Валидатор для <see cref="AddProductModel"/>
    /// </summary>
    public class AddProductModelValidator : AbstractValidator<AddProductModel>
    {
        private readonly IProductReadRepository productReadRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public AddProductModelValidator(IProductReadRepository productReadRepository)
        {
            this.productReadRepository = productReadRepository;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(Cnst.MinLen, Cnst.MaxNameLen)

                .MustAsync(async (x, cancellation) => await NameIsUniqueAsync(x, cancellation))
                .WithMessage(x => $"Товар с названием {x} уже существует.")
                ;

            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty()
                .LessThan(decimal.MaxValue)
                .GreaterThan(0)
                ;
        }

        private async Task<bool> NameIsUniqueAsync(string name, CancellationToken cancellationToken)
        {
            var products = await productReadRepository.GetAll(cancellationToken);
            var product = products.FirstOrDefault(x => x.Name == name);
            return product == null;
        }
    }
}
