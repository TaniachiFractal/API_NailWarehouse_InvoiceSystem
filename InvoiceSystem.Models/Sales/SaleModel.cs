using InvoiceSystem.Database.Contracts.ModelInterfaces;

namespace InvoiceSystem.Models.Sales
{
    /// <summary>
    /// Модель показа данных о продаже
    /// </summary>
    public class SaleModel : AddSaleModel, IUniqueID
    {
        /// <inheritdoc/> 
        public Guid Id { get; set; }
    }
}
