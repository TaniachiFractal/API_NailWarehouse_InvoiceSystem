using System.Globalization;
using Ahatornn.TestGenerator;
using FluentAssertions;
using InvoiceSystem.Common;
using InvoiceSystem.Database;
using InvoiceSystem.Exceptions;
using InvoiceSystem.Models;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Customers;
using InvoiceSystem.Repositories.Invoices;
using InvoiceSystem.Repositories.Products;
using InvoiceSystem.Repositories.Sales;
using InvoiceSystem.Services.Contracts;
using InvoiceSystem.TestsBase;
using Xunit;

namespace InvoiceSystem.Services.Tests.Services
{
    /// <summary>
    /// Тесты <see cref="MainService"/>
    /// </summary>
    [Collection(nameof(DBTestsCollection))]
    public class MainServiceTests
    {
        private const decimal Tax = 0.2M;

        private readonly InvcSysDBContext dBContext;
        private readonly CancellationToken cancellationToken;
        private readonly IMainService service;
        private readonly IDateTimeOffsetProvider dateTime;

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainServiceTests(DBTestsFixture fixture)
        {
            dBContext = fixture.DbContext;
            cancellationToken = fixture.CancellationToken;
            dateTime = fixture.DateTimeMock;
            service = new MainService
                (
                new CustomerReadRepository(dBContext),
                new InvoiceReadRepository(dBContext),
                new ProductReadRepository(dBContext),
                new SaleReadRepository(dBContext)
                );

            ClearDb();
        }

        /// <summary>
        /// Выдаёт ошибку если не найдена накладная
        /// </summary>
        [Fact]
        public async Task GetFullInvoiceInfoShouldThrowInvoiceNotFound()
        {
            // Act
            try
            {
                await service.GetFullInvoiceInfo(Guid.NewGuid(), cancellationToken);
            }
            // Assert
            catch (Exception ex)
            {
                Assert.True(ex.GetType() == typeof(NotFoundException));
            }
        }

        /// <summary>
        /// Получение всех данных накладной работает
        /// </summary>
        [Fact]
        public async Task GetFullInvoiceInfoWorks()
        {
            // Arrange
            var customer = TestEntityProvider.Shared.Create<Customer>();
            var invoice = TestEntityProvider.Shared.Create<Invoice>();
            #region sale 0

            var product0 = TestEntityProvider.Shared.Create<Product>();
            product0.Price = 4;

            var sale0 = TestEntityProvider.Shared.Create<Sale>();
            sale0.SoldCount = 4;

            sale0.InvoiceId = invoice.Id;
            sale0.ProductId = product0.Id;

            #endregion
            #region sale 1

            var product1 = TestEntityProvider.Shared.Create<Product>();
            product1.Price = 7;

            var sale1 = TestEntityProvider.Shared.Create<Sale>();
            sale0.SoldCount = 3;

            sale1.InvoiceId = invoice.Id;
            sale1.ProductId = product1.Id;

            #endregion
            invoice.CustomerId = customer.Id;

            dBContext.Customers.Add(customer);
            dBContext.Invoices.Add(invoice);
            dBContext.Products.AddRange(product0, product1);
            dBContext.Sales.AddRange(sale0, sale1);

            dBContext.SaveChanges();

            var sumNoTax = product0.Price * sale0.SoldCount + product1.Price * sale1.SoldCount;
            var sumWTax = sumNoTax * (1 + Tax);

            var fullInvoiceInfo = new FullInvoiceInfoModel()
            {
                InvoiceId = invoice.Id,
                Number = (uint)invoice.Id.GetHashCode(),
                ExecDate = invoice.ExecutionDate.Date,
                CustomerId = customer.Id,
                CustomerName = customer.Name,
                CustomerAddress = customer.Address,
                CustomerINN = customer.INN,
                Products = new List<ProductInvoiceListingModel>
                {
                    new()
                    {
                        ProductId = product0.Id,
                        Name = product0.Name,
                        Count = sale0.SoldCount,
                        Price = product0.Price,
                        Summary = sale0.SoldCount * product0.Price
                    },
                    new()
                    {
                        ProductId = product1.Id,
                        Name = product1.Name,
                        Count = sale1.SoldCount,
                        Price = product1.Price,
                        Summary = sale1.SoldCount * product1.Price
                    },
                },
                Tax = sumWTax - sumNoTax,
                FullSummary = sumWTax,
            };

            // Act
            var result = await service.GetFullInvoiceInfo(invoice.Id, cancellationToken);

            // Assert
            result.Should().NotBeNull().And.BeEquivalentTo(fullInvoiceInfo);
        }

        private void ClearDb()
        {
            dBContext.Customers.RemoveRange(dBContext.Customers);
            dBContext.Invoices.RemoveRange(dBContext.Invoices);
            dBContext.Products.RemoveRange(dBContext.Products);
            dBContext.Sales.RemoveRange(dBContext.Sales);
            dBContext.SaveChanges();
        }
    }
}
