using Ahatornn.TestGenerator;
using FluentValidation;
using FluentValidation.TestHelper;
using InvoiceSystem.Common;
using InvoiceSystem.Database;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Repositories.Contracts.Customers;
using InvoiceSystem.Repositories.Contracts.Invoices;
using InvoiceSystem.Repositories.Customers;
using InvoiceSystem.Repositories.Invoices;
using InvoiceSystem.Services.Models.Customers;
using InvoiceSystem.TestsBase;
using Xunit;

namespace InvoiceSystem.Services.Tests.Validators.BaseObjectModelValidators
{
    /// <summary>
    /// Тесты <see cref="AddCustomerModelValidator"/> и <see cref="CustomerModelValidator"/>
    /// </summary>
    [Collection(nameof(DBTestsCollection))]
    public abstract class BaseInvoiceModelValidatorTests<TModel> where TModel : AddInvoiceModel, new()
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        readonly protected InvcSysDBContext dBContext;
        /// <summary>
        /// Валидатор
        /// </summary>
        readonly protected AbstractValidator<TModel> validator;

        private readonly CancellationToken cancellationToken;

        /// <summary>
        /// Конструктор валидатора
        /// </summary>
        protected abstract AbstractValidator<TModel> Validator(IInvoiceReadRepository readRepository);

        /// <summary>
        /// Конструктор
        /// </summary>
        public BaseInvoiceModelValidatorTests(DBTestsFixture fixture)
        {
            dBContext = fixture.DbContext;
            cancellationToken = fixture.CancellationToken;
            validator = Validator(new InvoiceReadRepository(dBContext));
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

        public ay

        #endregion

    }
}
