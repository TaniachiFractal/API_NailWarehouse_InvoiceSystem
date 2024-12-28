using Ahatornn.TestGenerator;
using AutoMapper;
using InvoiceSystem.Api.Controllers;
using InvoiceSystem.Api.Models;
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
using InvoiceSystem.Services;
using InvoiceSystem.TestsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;

namespace InvoiceSystem.Api.Tests.Controllers
{
    /// <summary>
    /// Тесты <see cref="MainController"/>
    /// </summary>
    [Collection(nameof(DBTestsCollection))]
    public class MainControllerTests
    {
        private readonly InvcSysDBContext dBContext;
        private readonly CancellationToken cancellationToken;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly MainController controller;

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainControllerTests(DBTestsFixture fixture)
        {
            dBContext = fixture.DbContext;
            cancellationToken = fixture.CancellationToken;
            logger = fixture.Logger;

            mapper = new Mapper(
                new MapperConfiguration(x =>
                {
                    x.CreateMap<ProductInvoiceListingModel, ProductInvoiceListingApiModel>();
                    x.CreateMap<FullInvoiceInfoModel, FullInvoiceInfoApiModel>()
                        .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

                }));

            controller = new MainController(
                new MainService(
                    new CustomerReadRepository(dBContext),
                    new InvoiceReadRepository(dBContext),
                    new ProductReadRepository(dBContext),
                    new SaleReadRepository(dBContext)
                    ),
                mapper,
                logger
                );
        }

        /// <summary>
        /// Получение по ID выдаёт ошибку не найдено
        /// </summary>
        [Fact]
        public async Task GetByIdThrowsNotFound()
        {
            // Arrange
            var invoice = TestEntityProvider.Shared.Create<Invoice>();
            invoice.DeletedDate = DateTime.UtcNow;
            dBContext.Add(invoice);
            dBContext.SaveChanges();

            // Act
            try
            {
                await controller.GetById(Guid.NewGuid(), cancellationToken);
            }
            // Assert
            catch (Exception ex)
            {
                Assert.True(ex.GetType() == typeof(NotFoundException));
            }
        }

        /// <summary>
        /// Получение по ID работает
        /// </summary>
        [Fact]
        public async Task GetByIdWorks()
        {
            // Arrange
            var customer = TestEntityProvider.Shared.Create<Customer>();
            var invoice = TestEntityProvider.Shared.Create<Invoice>();
            #region sale 0

            var product0 = TestEntityProvider.Shared.Create<Product>();
            product0.Price = 4;

            var sale0 = TestEntityProvider.Shared.Create<Sale>();

            sale0.InvoiceId = invoice.Id;
            sale0.ProductId = product0.Id;

            #endregion
            #region sale 1

            var product1 = TestEntityProvider.Shared.Create<Product>();
            product1.Price = 7;

            var sale1 = TestEntityProvider.Shared.Create<Sale>();

            sale1.InvoiceId = invoice.Id;
            sale1.ProductId = product1.Id;

            #endregion
            invoice.CustomerId = customer.Id;

            dBContext.Customers.Add(customer);
            dBContext.Invoices.Add(invoice);
            dBContext.Products.AddRange(product0, product1);
            dBContext.Sales.AddRange(sale0, sale1);

            dBContext.SaveChanges();

            // Act
            var result = await controller.GetById(invoice.Id, cancellationToken);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<FullInvoiceInfoApiModel>(okResult.Value);
        }

    }
}
