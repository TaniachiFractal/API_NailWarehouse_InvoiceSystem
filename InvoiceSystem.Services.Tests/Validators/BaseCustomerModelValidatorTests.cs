using FluentValidation.TestHelper;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Services.Models.Customers;
using Xunit;

namespace InvoiceSystem.Services.Tests.Validators
{
    /// <summary>
    /// Тесты <see cref="BaseCustomerModelValidator"/>
    /// </summary>
    public class BaseCustomerModelValidatorTests
    {
        private readonly BaseCustomerModelValidator validator;

        /// <summary>ctor</summary>
        public BaseCustomerModelValidatorTests()
        {
            validator = new BaseCustomerModelValidator();
        }

        #region INN

        /// <summary>
        /// Неправильный ИНН - длина меньше 12
        /// </summary>
        [Fact]
        public void ShouldHaveErrorForINNWrongLengthTooSmall()
        {
            // Arrange
            var model = new AddCustomerModel() { INN = "12345678901" };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.INN);
        }

        /// <summary>
        /// Неправильный ИНН - длина больше 12
        /// </summary>
        [Fact]
        public void ShouldHaveErrorForINNWrongLengthTooBig()
        {
            // Arrange
            var model = new AddCustomerModel() { INN = "1234567890123" };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.INN);
        }

        /// <summary>
        /// Неправильный ИНН - не цифры
        /// </summary>
        [Fact]
        public void ShouldHaveErrorForINNNotNumbers()
        {
            // Arrange
            var model = new AddCustomerModel() { INN = "123" };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.INN);
        }

        #endregion

    }
}
