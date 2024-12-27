using FluentValidation;
using FluentValidation.TestHelper;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Services.Models.Products;
using InvoiceSystem.Services.Tests.Validators.BaseObjectModelValidators;
using InvoiceSystem.TestsBase;
using Xunit;

namespace InvoiceSystem.Services.Tests.Validators.ObjectModelValidators
{
    /// <summary>
    /// Тесты <see cref="AddProductModelValidator"/>
    /// </summary>
    public class ProductModelValidatorTests : BaseProductModelValidatorTests<ProductModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ProductModelValidatorTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override AbstractValidator<ProductModel> Validator()
            => new ProductModelValidator();

        /// <summary>
        /// Нет Id
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForIdEmptyAsync()
        {
            // Arrange
            var model = new ProductModel();

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
