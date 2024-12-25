using Ahatornn.TestGenerator;
using FluentValidation;
using FluentValidation.TestHelper;
using InvoiceSystem.Common;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Repositories.Contracts.Customers;
using InvoiceSystem.Services.Models.Customers;
using InvoiceSystem.Services.Tests.Validators.BaseObjectModelValidators;
using InvoiceSystem.TestsBase;
using Xunit;

namespace InvoiceSystem.Services.Tests.Validators.AddObjectModelValidators
{
    /// <summary>
    /// Тесты <see cref="AddCustomerModelValidator"/>
    /// </summary>
    [Collection(nameof(DBTestsCollection))]
    public class AddCustomerModelValidatorTests : BaseCustomerModelValidatorTests<AddCustomerModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AddCustomerModelValidatorTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override AbstractValidator<AddCustomerModel> Validator(ICustomerReadRepository readRepository)
            => new AddCustomerModelValidator(readRepository);

        /// <summary>
        /// ИНН уже есть в БД
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForINNExists()
        {
            // Arrange
            var inn = Cnst.NewINN();

            dBContext.Customers.Add(TestEntityProvider.Shared.Create<Customer>(x => x.INN = inn));
            dBContext.SaveChanges();

            var model = new AddCustomerModel() { INN = inn };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.INN);
        }
    }
}
