using FluentValidation;
using FluentValidation.TestHelper;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Contracts.Invoices;
using InvoiceSystem.Repositories.Contracts.Products;
using InvoiceSystem.Services.Models.Sales;
using InvoiceSystem.Services.Tests.Validators.BaseObjectModelValidators;
using InvoiceSystem.TestsBase;
using Xunit;

namespace InvoiceSystem.Services.Tests.Validators.ObjectModelValidators
{
    /// <summary>
    /// Тесты <see cref="SaleModelValidator"/>
    /// </summary>
    public class SaleModelValidatorTests : BaseSaleModelValidatorTests<SaleModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public SaleModelValidatorTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override AbstractValidator<SaleModel> Validator(IProductReadRepository productReadRepository, IInvoiceReadRepository invoiceReadRepository)
            => new SaleModelValidator(productReadRepository, invoiceReadRepository);

        /// <summary>
        /// Нет Id
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForIdEmptyAsync()
        {
            // Arrange
            var model = new SaleModel();

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
