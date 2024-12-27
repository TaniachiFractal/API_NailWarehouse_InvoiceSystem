using Ahatornn.TestGenerator;
using FluentValidation;
using FluentValidation.TestHelper;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Repositories.Contracts.Customers;
using InvoiceSystem.Services.Models.Customers;
using InvoiceSystem.Services.Tests.Validators.BaseObjectModelValidators;
using InvoiceSystem.TestsBase;
using Xunit;

namespace InvoiceSystem.Services.Tests.Validators.ObjectModelValidators
{
    /// <summary>
    /// Тесты <see cref="CustomerModelValidator"/>
    /// </summary>
    public class CustomerModelValidatorTests : BaseCustomerModelValidatorTests<CustomerModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CustomerModelValidatorTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override AbstractValidator<CustomerModel> Validator(ICustomerReadRepository readRepository)
            => new CustomerModelValidator(readRepository);

        /// <summary>
        /// ИНН уже есть в БД
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForINNExistsAsync()
        {
            // Arrange
            var inn = Common.Com.NewINN();
            var customer = TestEntityProvider.Shared.Create<Customer>(x => x.INN = inn);

            dBContext.Customers.Add(customer);
            dBContext.SaveChanges();

            var model = new CustomerModel() { INN = inn };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.INN);
        }

        /// <summary>
        /// ИНН уже есть в БД, но это тот же самый объект
        /// </summary>
        [Fact]
        public async Task ShouldNotHaveErrorForINNExistsAsync()
        {
            // Arrange
            var inn = Common.Com.NewINN();
            var customer = TestEntityProvider.Shared.Create<Customer>(x => x.INN = inn);

            dBContext.Customers.Add(customer);
            dBContext.SaveChanges();

            var model = new CustomerModel() { INN = customer.INN, Id = customer.Id };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.INN);
        }

        /// <summary>
        /// Нет Id
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForIdEmptyAsync()
        {
            // Arrange
            var model = new CustomerModel();

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
