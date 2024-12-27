using FluentValidation;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Services.Models.Products;
using InvoiceSystem.Services.Tests.Validators.BaseObjectModelValidators;
using InvoiceSystem.TestsBase;

namespace InvoiceSystem.Services.Tests.Validators.AddObjectModelValidators
{
    /// <summary>
    /// Тесты <see cref="AddProductModelValidator"/>
    /// </summary>
    public class AddProductModelValidatorTests : BaseProductModelValidatorTests<AddProductModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AddProductModelValidatorTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override AbstractValidator<AddProductModel> Validator()
            => new AddProductModelValidator();
    }
}
