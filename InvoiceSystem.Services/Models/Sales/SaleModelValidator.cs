using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Contracts.Invoices;
using InvoiceSystem.Repositories.Contracts.Products;

namespace InvoiceSystem.Services.Models.Sales
{
    /// <summary>
    /// Валидатор для <see cref="SaleModel"/>
    /// </summary>
    public class SaleModelValidator : UniqueIdValidator<SaleModel, AddSaleModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public SaleModelValidator(IProductReadRepository productReadRepository, IInvoiceReadRepository invoiceReadRepository)
            : base(new AddSaleModelValidator(productReadRepository, invoiceReadRepository))
        {
        }
    }
}
