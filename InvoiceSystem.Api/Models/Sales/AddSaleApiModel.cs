using InvoiceSystem.Models.Interfaces;

namespace InvoiceSystem.Api.Models.Sales
{
    /// <summary>
    /// Модель добавления и изменения данных о продаже
    /// </summary>
    public class AddSaleApiModel : ISale
    {
        /// <inheritdoc/> 
        public Guid ProductId { get; set; }

        /// <inheritdoc/>
        public Guid InvoiceId { get; set; }

        /// <inheritdoc/>
        public int SoldCount { get; set; }
    }
}
