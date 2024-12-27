namespace InvoiceSystem.Database.Contracts.ModelInterfaces
{
    /// <summary>
    /// Возможность мягкого удаления
    /// </summary>
    public interface ISoftDeleted
    {
        /// <summary>
        /// Дата удаления
        /// </summary>
        public DateTimeOffset? DeletedDate { get; set; }
    }
}
