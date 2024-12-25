using System.Configuration;
using FluentValidation;
using FluentValidation.TestHelper;
using InvoiceSystem.Models.Interfaces;
using InvoiceSystem.Repositories.Contracts.Customers;
using InvoiceSystem.Repositories.Customers;
using InvoiceSystem.Services.Models.Products;
using InvoiceSystem.TestsBase;
using Xunit;

namespace InvoiceSystem.Services.Tests.Validators.BaseObjectModelValidators
{
    /// <summary>
    /// Тесты <see cref="AddProductModelValidator"/> и <see cref="ProductModelValidator"/>
    /// </summary>
    [Collection(nameof(DBTestsCollection))]
    public abstract class BaseProductModelValidatorTests<TModel> : BaseValidatorTests<TModel>
        where TModel : class, IProduct, new()
    {
        /// <summary>
        /// Конструктор валидатора
        /// </summary>
        protected abstract AbstractValidator<TModel> Validator();

        /// <summary>
        /// Конструктор
        /// </summary>
        protected BaseProductModelValidatorTests(DBTestsFixture fixture) : base(fixture)
        {
            validator = Validator();
        }

        #region Name

        /// <summary>
        /// Неправильное название - пусто
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForNameEmptyAsync()
        {
            // Arrange
            var model = new TModel();

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        /// <summary>
        /// Неправильное название - меньше 3
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForNameWrongLengthTooSmallAsync()
        {
            // Arrange
            var model = new TModel() { Name = new string('1', 2) };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        /// <summary>
        /// Неправильное название - больше 1023
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForNameWrongLengthTooBigAsync()
        {
            // Arrange
            var model = new TModel() { Name = new string('1', 1024) };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        /// <summary>
        /// Правильное название
        /// </summary>
        [Fact]
        public async Task ShouldAcceptNameAsync()
        {
            // Arrange
            var model = new TModel() { Name = new string('1', 9) };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        #endregion

        #region Price

        /// <summary>
        /// Неправильная цена - отрицательная
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForPriceNegativeAsync()
        {
            // Arrange
            var model = new TModel() { Price = -1 };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        /// <summary>
        /// Неправильная цена - слишком большая
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForPriceTooBigAsync()
        {
            // Arrange
            var model = new TModel() { Price = decimal.MaxValue };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        /// <summary>
        /// Правильная цена
        /// </summary>
        [Fact]
        public async Task ShouldAcceptPriceAsync()
        {
            // Arrange
            var model = new TModel() { Price = 29.9M };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Price);
        }

        #endregion

    }
}
