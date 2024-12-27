namespace InvoiceSystem.Database.Contracts.ModelInterfaces
{
    /// <summary>
    /// Возможность добавления аудита
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}
