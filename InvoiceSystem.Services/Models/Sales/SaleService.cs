using AutoMapper;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Contracts.Sales;
using InvoiceSystem.Services.Contracts.Models.Sales;

namespace InvoiceSystem.Services.Models.Sales
{
    /// <inheritdoc cref="ISaleService"/>
    public class SaleService
        : DBObjectService<AddSaleModel, SaleModel, Sale>,
        ISaleService
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public SaleService(IMapper mapper, ISaleReadRepository readRepository, ISaleWriteRepository writeRepository, IUnitOfWork unitOfWork)
            : base(mapper, readRepository, writeRepository, unitOfWork)
        {
        }
    }
}
