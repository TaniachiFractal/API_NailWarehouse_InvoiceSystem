using InvoiceSystem.Models.Sales;

namespace InvoiceSystem.Services.Contracts.Models.Sales
{
    /// <summary>
    /// Сервис продаж
    /// </summary>
    public interface ISaleService : IDBobjectService<AddSaleModel, SaleModel, Sale>
    {
    }
}
