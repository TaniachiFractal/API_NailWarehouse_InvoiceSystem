using InvoiceSystem.Models.Sales;

namespace InvoiceSystem.Services.Contracts.ModelServices
{
    /// <summary>
    /// Сервис для <see cref="Sale"/>
    /// </summary>
    public interface ISaleService : IDBobjectService<AddSaleModel, SaleModel>
    {
    }
}
