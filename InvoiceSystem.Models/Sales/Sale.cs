using InvoiceSystem.Models.Interfaces;

namespace InvoiceSystem.Models.Sales
{
    /// <summary>
    /// Запись о продаже товара
    /// </summary>
    public class Sale : DBObject, ISale
    {
        /// <inheritdoc/> 
        public Guid ProductId { get; set; }

        /// <inheritdoc/> 
        public Guid InvoiceId { get; set; }

        /// <inheritdoc/>
        public int SoldCount { get; set; }
    }
}
