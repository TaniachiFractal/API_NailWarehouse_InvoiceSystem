using AutoMapper;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Repositories.Contracts.Invoices;
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
        public InvoiceService(IMapper mapper, IInvoiceReadRepository readRepository, IInvoiceWriteRepository writeRepository, IUnitOfWork unitOfWork)
            : base(mapper, readRepository, writeRepository, unitOfWork)
        {
        }
    }
}
