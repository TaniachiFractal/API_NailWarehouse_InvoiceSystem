using FluentValidation;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Repositories.Contracts.Customers;
using InvoiceSystem.Services.Models.Invoices;
using InvoiceSystem.Services.Tests.Validators.BaseObjectModelValidators;
using InvoiceSystem.TestsBase;

namespace InvoiceSystem.Services.Tests.Validators.AddObjectModelValidators
{
    /// <summary>
    /// Тесты <see cref="AddInvoiceModelValidator"/>
    /// </summary>
    public class AddInvoiceModelValidatorTests : BaseInvoiceModelValidatorTests<AddInvoiceModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AddInvoiceModelValidatorTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override AbstractValidator<AddInvoiceModel> Validator(ICustomerReadRepository readRepository)
            => new AddInvoiceModelValidator(readRepository);
    }
}
