using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Services.Contracts.Models.Invoices;

namespace InvoiceSystem.Services.Models.Invoices
{
    /// <inheritdoc cref="IInvoiceValidationService"/>
    public class InvoiceValidationService
        : DBObjectValidationService
        <InvoiceModel, AddInvoiceModel, InvoiceModelValidator, AddInvoiceModelValidator>,
        IInvoiceValidationService
    {
    }
}
