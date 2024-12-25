using FluentValidation;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Contracts.Invoices;
using InvoiceSystem.Repositories.Contracts.Products;
using InvoiceSystem.Services.Models.Sales;
using InvoiceSystem.Services.Tests.Validators.BaseObjectModelValidators;
using InvoiceSystem.TestsBase;

namespace InvoiceSystem.Services.Tests.Validators.AddObjectModelValidators
{
    /// <summary>
    /// Тесты <see cref="AddSaleModelValidator"/>
    /// </summary>
    public class AddSaleModelValidatorTests : BaseSaleModelValidatorTests<AddSaleModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AddSaleModelValidatorTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override AbstractValidator<AddSaleModel> Validator(IProductReadRepository productReadRepository, IInvoiceReadRepository invoiceReadRepository)
            => new AddSaleModelValidator(productReadRepository, invoiceReadRepository);
    }
}
