using Ahatornn.TestGenerator;
using FluentValidation;
using FluentValidation.TestHelper;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Models.Interfaces;
using InvoiceSystem.Repositories.Contracts.Customers;
using InvoiceSystem.Repositories.Customers;
using InvoiceSystem.Services.Models.Invoices;
using InvoiceSystem.TestsBase;
using Xunit;

namespace InvoiceSystem.Services.Tests.Validators.BaseObjectModelValidators
{
    /// <summary>
    /// Тесты <see cref="AddInvoiceModelValidator"/> и <see cref="InvoiceModelValidator"/>
    /// </summary>
    [Collection(nameof(DBTestsCollection))]
    public abstract class BaseInvoiceModelValidatorTests<TModel> : BaseValidatorTests<TModel>
        where TModel : class, IInvoice, new()
    {
        /// <summary>
        /// Конструктор валидатора
        /// </summary>
        protected abstract AbstractValidator<TModel> Validator(ICustomerReadRepository readRepository);

        /// <summary>
        /// Конструктор
        /// </summary>
        protected BaseInvoiceModelValidatorTests(DBTestsFixture fixture) : base(fixture)
        {
            validator = Validator(new CustomerReadRepository(dBContext));
        }

        #region CustomerId

        /// <summary>
        /// Неправильный ID покупателя - пусто
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForCustomerIdEmptyAsync()
        {
            // Arrange
            var model = new TModel();

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CustomerId);
        }

        /// <summary>
        /// Неправильный ID покупателя - не существует
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForCustomerIdDoesntExistAsync()
        {
            // Arrange
            var model = new TModel() { CustomerId = Guid.NewGuid() };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CustomerId);
        }

        /// <summary>
        /// Правильный ID покупателя
        /// </summary>
        [Fact]
        public async Task ShouldAcceptCustomerIdAsync()
        {
            // Arrange
            var customer = TestEntityProvider.Shared.Create<Customer>();
            dBContext.Customers.Add(customer);
            dBContext.SaveChanges();

            var model = new TModel { CustomerId = customer.Id };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.CustomerId);
        }

        #endregion

        #region Exec Date

        /// <summary>
        /// Даты исполения нет
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForExecDateEmptyAsync()
        {
            // Arrange
            var model = new TModel();

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ExecutionDate);
        }

        #endregion

    }
}
