using FluentValidation;
using FluentValidation.TestHelper;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Repositories.Contracts.Customers;
using InvoiceSystem.Services.Models.Invoices;
using InvoiceSystem.Services.Tests.Validators.BaseObjectModelValidators;
using InvoiceSystem.TestsBase;
using Xunit;

namespace InvoiceSystem.Services.Tests.Validators.ObjectModelValidators
{
    /// <summary>
    /// Тесты <see cref="InvoiceModelValidator"/>
    /// </summary>
    public class InvoiceModelValidatorTests : BaseInvoiceModelValidatorTests<InvoiceModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public InvoiceModelValidatorTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override AbstractValidator<InvoiceModel> Validator(ICustomerReadRepository readRepository)
            => new InvoiceModelValidator(readRepository);


        /// <summary>
        /// Нет Id
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForIdEmptyAsync()
        {
            // Arrange
            var model = new InvoiceModel();

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
