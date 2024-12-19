using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Contracts.Invoices;
using InvoiceSystem.Repositories.Contracts.Products;
using InvoiceSystem.Services.Contracts.Models.Sales;

namespace InvoiceSystem.Services.Models.Sales
{
    /// <inheritdoc cref="ISaleValidationService"/>
    public class SaleValidationService : DBObjectValidationService, ISaleValidationService
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public SaleValidationService(IProductReadRepository productReadRepository, IInvoiceReadRepository invoiceReadRepository)
            : base()
        {
            validators.Add(typeof(AddSaleModel), new AddSaleModelValidator(productReadRepository, invoiceReadRepository));
            validators.Add(typeof(SaleModel), new SaleModelValidator(productReadRepository, invoiceReadRepository));
        }
    }
}
