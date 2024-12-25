using FluentValidation;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Contracts.Invoices;
using InvoiceSystem.Repositories.Contracts.Products;

namespace InvoiceSystem.Services.Models.Sales
{
    /// <summary>
    /// Валидатор для <see cref="AddSaleModel"/>
    /// </summary>
    public class AddSaleModelValidator : AbstractValidator<AddSaleModel>
    {
        private readonly IInvoiceReadRepository invoiceReadRepository;
        private readonly IProductReadRepository productReadRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public AddSaleModelValidator(IProductReadRepository productReadRepository, IInvoiceReadRepository invoiceReadRepository)
        {
            this.invoiceReadRepository = invoiceReadRepository;
            this.productReadRepository = productReadRepository;

            RuleForProductId();
            RuleForInvoiceId();
            RuleForSoldCount();
        }

        /// <summary>
        /// Правило для ID товара
        /// </summary>
        public void RuleForProductId()
        {
            RuleFor(x => x.ProductId)
                .NotNull()
                .NotEmpty()
                .MustAsync(async (x, cancellation) => await ProductExists(x, cancellation))
                .WithMessage(x => $"Товара с ID {x.ProductId} не существует.")
                ;
        }

        /// <summary>
        /// Правило для ID накладной
        /// </summary>
        public void RuleForInvoiceId()
        {
            RuleFor(x => x.InvoiceId)
                .NotNull()
                .NotEmpty()

                .MustAsync(async (x, cancellation) => await InvoiceExists(x, cancellation))
                .WithMessage(x => $"Накладной с ID {x.ProductId} не существует.")
                ;
        }

        /// <summary>
        /// Правило для количества проданных единиц
        /// </summary>
        public void RuleForSoldCount()
        {
            RuleFor(x => x.SoldCount)
                .NotNull()
                .NotEmpty()
                .LessThan(int.MaxValue)
                .GreaterThan(0)
                ;
        }

        private async Task<bool> ProductExists(Guid id, CancellationToken cancellation)
        {
            var product = await productReadRepository.GetById(id, cancellation);
            return product != null;
        }

        private async Task<bool> InvoiceExists(Guid id, CancellationToken cancellation)
        {
            var invoice = await invoiceReadRepository.GetById(id, cancellation);
            return invoice != null;
        }
    }
}
