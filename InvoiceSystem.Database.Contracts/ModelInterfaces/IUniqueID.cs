namespace InvoiceSystem.Database.Contracts.ModelInterfaces
{
    /// <summary>
    /// Объект с уникальным идентификатором типа <see cref="Guid"/>
    /// </summary>
    public interface IUniqueID
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
