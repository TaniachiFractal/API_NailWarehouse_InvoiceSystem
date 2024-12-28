using System.Globalization;
using InvoiceSystem.Common;
using InvoiceSystem.Exceptions;
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

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainService(
            ICustomerReadRepository customerRep,
            IInvoiceReadRepository invoiceRep,
            IProductReadRepository productRep,
            ISaleReadRepository saleRep)
        {
            this.customerRep = customerRep;
            this.invoiceRep = invoiceRep;
            this.productRep = productRep;
            this.saleRep = saleRep;
        }

        async Task<FullInvoiceInfoModel> IMainService.GetFullInvoiceInfo(Guid invoiceId, CancellationToken cancellationToken)
        {
            var invoice = await invoiceRep.GetById(invoiceId, cancellationToken) ?? throw new NotFoundException(invoiceId, typeof(Invoice));
            var customer = await customerRep.GetById(invoice.CustomerId, cancellationToken) ?? throw new NotFoundException(invoiceId, typeof(Customer));
            var sales = await saleRep.GetAllWithInvoiceId(invoiceId, cancellationToken);

            var sumNoTax = 0M;
            var productListings = new List<ProductInvoiceListingModel>();
            foreach (var sale in sales)
            {
                var product = await productRep.GetById(sale.ProductId, cancellationToken) ?? throw new NotFoundException(invoiceId, typeof(Product));
                productListings.Add(new ProductInvoiceListingModel
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Count = sale.SoldCount,
                    Price = product.Price,
                    Summary = sale.SoldCount * product.Price,
                });
                sumNoTax += product.Price * sale.SoldCount;
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
