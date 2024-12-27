using InvoiceSystem.Database.Contracts.ModelInterfaces;

namespace InvoiceSystem.Api.Models.Sales
{
    /// <summary>
    /// Модель показа данных о продаже
    /// </summary>
    public class SaleApiModel : AddSaleApiModel, IUniqueID
    {
        /// <inheritdoc/> 
        public Guid Id { get; set; }
    }
}
