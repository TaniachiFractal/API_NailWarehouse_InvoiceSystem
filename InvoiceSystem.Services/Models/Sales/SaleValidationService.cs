using InvoiceSystem.Models.Sales;
using InvoiceSystem.Services.Contracts.Models.Sales;

namespace InvoiceSystem.Services.Models.Sales
{
    /// <inheritdoc cref="ISaleValidationService"/>
    public class SaleValidationService
        : DBObjectValidationService
        <SaleModel, AddSaleModel, SaleModelValidator, AddSaleModelValidator>,
        ISaleValidationService
    {
    }
}
