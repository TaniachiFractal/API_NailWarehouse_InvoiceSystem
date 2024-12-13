using AutoMapper;
using InvoiceSystem.Database;
using InvoiceSystem.Models.Sales;
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
        public SaleService(InvcSysDBContext dbContext, IMapper mapper) : base(dbContext, dbContext.Sales, mapper)
        {
        }
    }
}
