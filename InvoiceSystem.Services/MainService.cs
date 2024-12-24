using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Xml.Linq;
using InvoiceSystem.Common;
using InvoiceSystem.Models;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Repositories.Contracts.Customers;
using InvoiceSystem.Repositories.Contracts.Invoices;
using InvoiceSystem.Repositories.Contracts.Products;
using InvoiceSystem.Repositories.Contracts.Sales;
using InvoiceSystem.Services.Contracts;

namespace InvoiceSystem.Services
{
    /// <inheritdoc cref="IMainService"/>
    public class MainService : IMainService
    {
        private const decimal Tax = 0.2M;

        private readonly ICustomerReadRepository customerRep;
        private readonly IInvoiceReadRepository invoiceRep;
        private readonly IProductReadRepository productRep;
        private readonly ISaleReadRepository saleRep;
        private readonly IDateTimeOffsetProvider dateTime;

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainService(
            ICustomerReadRepository customerRep,
            IInvoiceReadRepository invoiceRep,
            IProductReadRepository productRep,
            ISaleReadRepository saleRep,
            IDateTimeOffsetProvider dateTime)
        {
            this.customerRep = customerRep;
            this.invoiceRep = invoiceRep;
            this.productRep = productRep;
            this.saleRep = saleRep;
            this.dateTime = dateTime;
        }

        async Task<string> IMainService.GetAllTablesAsSQLQueries(CancellationToken cancellationToken)
        {
            var output = string.Empty;

            var invoices = await invoiceRep.GetAll(cancellationToken);
            foreach (var i in invoices)
            {
                output += $"INSERT INTO Invoices(Id, CustomerId, ExecutionDate, CreatedDate) VALUES('{i.Id}', '{i.CustomerId}', '{i.ExecutionDate:yyyy-MM-dd}', '{dateTime.UtcNow:yyyy-MM-dd}');\n";
            }
            var products = await productRep.GetAll(cancellationToken);
            foreach (var i in products)
            {
                output += $"INSERT INTO Products(Id, Name, Price, CreatedDate) VALUES('{i.Id}', N'{i.Name}', {i.Price.ToString(new CultureInfo("en-US"))}, '{dateTime.UtcNow:yyyy-MM-dd}');\n";
            }
            var sales = await saleRep.GetAll(cancellationToken);
            foreach (var i in sales)
            {
                output += $"INSERT INTO Sales (Id, ProductId, InvoiceId, SoldCount, CreatedDate) VALUES ('{i.Id}', '{i.ProductId}', '{i.InvoiceId}', '{i.SoldCount}', '{dateTime.UtcNow:yyyy-MM-dd}');\n";
            }
            var customers = await customerRep.GetAll(cancellationToken);
            foreach (var i in customers)
            {
                output += $"INSERT INTO Customers (Id, Name, INN, Address, CreatedDate) VALUES ('{i.Id}', N'{i.Name}', '{i.INN}', N'{i.Address}', '{dateTime.UtcNow:yyyy-MM-dd}');\n";
            }
            return output;
        }

        async Task<FullInvoiceInfoModel> IMainService.GetFullInvoiceInfo(Guid invoiceId, CancellationToken cancellationToken)
        {
            var invoice = await invoiceRep.GetById(invoiceId, cancellationToken);
            var customer = await customerRep.GetById(invoice.CustomerId, cancellationToken);
            var sales = await saleRep.GetAllWithInvoiceId(invoiceId, cancellationToken);

            var sumNoTax = 0M;
            var productListings = new List<ProductInvoiceListingModel>();
            foreach (var sale in sales)
            {
                var product = await productRep.GetById(sale.ProductId, cancellationToken);
                productListings.Add(new ProductInvoiceListingModel
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Count = sale.SoldCount,
                    Price = product.Price,
                    Summary = sale.SoldCount * product.Price,
                });
                sumNoTax += product.Price;
            }

            var sumWTax = sumNoTax * (1 + Tax);

            return new FullInvoiceInfoModel
            {
                InvoiceId = invoiceId,
                Number = (uint)invoice.Id.GetHashCode(),
                ExecDate = invoice.ExecutionDate.Date,
                CustomerId = customer.Id,
                CustomerName = customer.Name,
                CustomerAddress = customer.Address,
                CustomerINN = customer.INN,
                Products = productListings,
                Tax = sumWTax - sumNoTax,
                FullSummary = sumWTax,
            };
        }
    }
}
