using AutoMapper;
using InvoiceSystem.Database;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Services.Contracts.Models.Invoices;

namespace InvoiceSystem.Services.Models.Invoices
{
    /// <inheritdoc cref="IInvoiceService"/>
    public class InvoiceService
        : DBObjectService<AddInvoiceModel, InvoiceModel, Invoice>,
        IInvoiceService
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public InvoiceService(InvcSysDBContext dbContext, IMapper mapper) : base(dbContext, dbContext.Invoices, mapper)
        {
        }
    }
}
