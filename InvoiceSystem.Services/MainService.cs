using InvoiceSystem.Models;
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
        public MainService(ICustomerReadRepository customerRep, IInvoiceReadRepository invoiceRep, IProductReadRepository productRep, ISaleReadRepository saleRep)
        {
            this.customerRep = customerRep;
            this.invoiceRep = invoiceRep;
            this.productRep = productRep;
            this.saleRep = saleRep;
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
                Number = invoice.Id.GetHashCode(),
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
