using FluentValidation;
using FluentValidation.TestHelper;
using InvoiceSystem.Models.Interfaces;
using InvoiceSystem.Repositories.Contracts.Customers;
using InvoiceSystem.Repositories.Customers;
using InvoiceSystem.Services.Models.Customers;
using InvoiceSystem.TestsBase;
using Xunit;

namespace InvoiceSystem.Services.Tests.Validators.BaseObjectModelValidators
{
    /// <summary>
    /// Тесты <see cref="AddCustomerModelValidator"/> и <see cref="CustomerModelValidator"/>
    /// </summary>
    [Collection(nameof(DBTestsCollection))]
    public abstract class BaseCustomerModelValidatorTests<TModel> : BaseValidatorTests<TModel>
        where TModel : class, ICustomer, new()
    {
        /// <summary>
        /// Конструктор валидатора
        /// </summary>
        protected abstract AbstractValidator<TModel> Validator(ICustomerReadRepository readRepository);

        /// <summary>
        /// Конструктор
        /// </summary>
        protected BaseCustomerModelValidatorTests(DBTestsFixture fixture) : base(fixture)
        {
            validator = Validator(new CustomerReadRepository(dBContext));
        }

        #region INN

        /// <summary>
        /// Неправильный ИНН - пусто
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForINNEmptyAsync()
        {
            // Arrange
            var model = new TModel();

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.INN);
        }

        /// <summary>
        /// Неправильный ИНН - длина меньше 12
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForINNWrongLengthTooSmallAsync()
        {
            // Arrange
            var model = new TModel() { INN = new string('1', 11) };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.INN);
        }

        /// <summary>
        /// Неправильный ИНН - длина больше 12
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForINNWrongLengthTooBigAsync()
        {
            // Arrange
            var model = new TModel() { INN = new string('1', 13) };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.INN);
        }

        /// <summary>
        /// Неправильный ИНН - не цифры
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForINNNotNumbersAsync()
        {
            // Arrange
            var model = new TModel() { INN = new string('a', 12) };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.INN);
        }

        /// <summary>
        /// Правильный ИНН
        /// </summary>
        [Fact]
        public async Task ShouldAcceptINNAsync()
        {
            // Arrange
            var model = new TModel() { INN = Common.Com.NewINN() };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.INN);
        }

        #endregion

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
        /// Неправильное название - больше 255
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForNameWrongLengthTooBigAsync()
        {
            // Arrange
            var model = new TModel() { Name = new string('1', 256) };

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

        #region Address

        /// <summary>
        /// Неправильный адрес - пусто
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForAddressEmptyAsync()
        {
            // Arrange
            var model = new TModel();

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Address);
        }

        /// <summary>
        /// Неправильный адрес - меньше 3
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForAddressWrongLengthTooSmallAsync()
        {
            // Arrange
            var model = new TModel() { Address = new string('1', 2) };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Address);
        }

        /// <summary>
        /// Неправильный адрес - больше 1023
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForAddressWrongLengthTooBigAsync()
        {
            // Arrange
            var model = new TModel() { Address = new string('1', 1024) };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Address);
        }

        /// <summary>
        /// Правильный адрес
        /// </summary>
        [Fact]
        public async Task ShouldAcceptAddressAsync()
        {
            // Arrange
            var model = new TModel() { Address = new string('1', 9) };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Address);
        }

        #endregion

    }
}
