using Ahatornn.TestGenerator;
using FluentValidation;
using FluentValidation.TestHelper;
using InvoiceSystem.Models.Interfaces;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Repositories.Contracts.Customers;
using InvoiceSystem.Repositories.Contracts.Invoices;
using InvoiceSystem.Repositories.Contracts.Products;
using InvoiceSystem.Repositories.Customers;
using InvoiceSystem.Repositories.Invoices;
using InvoiceSystem.Repositories.Products;
using InvoiceSystem.Services.Models.Sales;
using InvoiceSystem.TestsBase;
using Xunit;

namespace InvoiceSystem.Services.Tests.Validators.BaseObjectModelValidators
{
    /// <summary>
    /// Тесты <see cref="AddSaleModelValidator"/> и <see cref="SaleModelValidator"/>
    /// </summary>
    [Collection(nameof(DBTestsCollection))]
    public abstract class BaseSaleModelValidatorTests<TModel> : BaseValidatorTests<TModel>
        where TModel : class, ISale, new()
    {

        /// <summary>
        /// Конструктор валидатора
        /// </summary>
        protected abstract AbstractValidator<TModel> Validator(IProductReadRepository productReadRepository, IInvoiceReadRepository invoiceReadRepository);

        /// <summary>
        /// Конструктор
        /// </summary>
        protected BaseSaleModelValidatorTests(DBTestsFixture fixture) : base(fixture)
        {
            validator = Validator(new ProductReadRepository(dBContext), new InvoiceReadRepository(dBContext));
        }

        #region SoldCount

        /// <summary>
        /// Неправильное кол-во проданных единиц - меньше нуля
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForSoldCountNegativeAsync()
        {
            // Arrange
            var model = new TModel() { SoldCount = -1 };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.SoldCount);
        }

        /// <summary>
        /// Неправильное кол-во проданных единиц - слишком большое
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForSoldCountTooBigAsync()
        {
            // Arrange
            var model = new TModel() { SoldCount = int.MaxValue };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.SoldCount);
        }

        /// <summary>
        /// Правильное кол-во проданных единиц
        /// </summary>
        [Fact]
        public async Task ShouldAcceptSoldCountAsync()
        {
            // Arrange
            var model = new TModel() { SoldCount = 9 };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.SoldCount);
        }

        #endregion

        #region InvoiceId

        /// <summary>
        /// Неправильный ID накладной - пусто
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForInvoiceIdEmptyAsync()
        {
            // Arrange
            var model = new TModel();

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.InvoiceId);
        }

        /// <summary>
        /// Неправильный ID накладной - не существует
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForInvoiceIdDoesntExistAsync()
        {
            // Arrange
            var model = new TModel() { InvoiceId = Guid.NewGuid() };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.InvoiceId);
        }

        /// <summary>
        /// Правильный ID накладной
        /// </summary>
        [Fact]
        public async Task ShouldAcceptInvoiceIdAsync()
        {
            // Arrange
            var invoice = TestEntityProvider.Shared.Create<Invoice>();
            dBContext.Invoices.Add(invoice);
            dBContext.SaveChanges();

            var model = new TModel { InvoiceId = invoice.Id };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.InvoiceId);
        }

        #endregion

        #region ProductId

        /// <summary>
        /// Неправильный ID товара - пусто
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForProductIdEmptyAsync()
        {
            // Arrange
            var model = new TModel();

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ProductId);
        }

        /// <summary>
        /// Неправильный ID товара - не существует
        /// </summary>
        [Fact]
        public async Task ShouldHaveErrorForProductIdDoesntExistAsync()
        {
            // Arrange
            var model = new TModel() { ProductId = Guid.NewGuid() };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ProductId);
        }

        /// <summary>
        /// Правильный ID товара
        /// </summary>
        [Fact]
        public async Task ShouldAcceptProductIdAsync()
        {
            // Arrange
            var product = TestEntityProvider.Shared.Create<Product>();
            dBContext.Products.Add(product);
            dBContext.SaveChanges();

            var model = new TModel { ProductId = product.Id };

            // Act
            var result = await validator.TestValidateAsync(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.ProductId);
        }

        #endregion

    }
}
