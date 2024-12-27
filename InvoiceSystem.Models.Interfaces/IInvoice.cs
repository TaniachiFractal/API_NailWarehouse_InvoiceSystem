namespace InvoiceSystem.Models.Interfaces
{
    /// <summary>
    /// Имеет поля данных накладной
    /// </summary>
    public interface IInvoice
    {
        /// <summary>
        /// ID поставщика
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Дата исполнения
        /// </summary>
        public DateTime ExecutionDate { get; set; }
    }
}
