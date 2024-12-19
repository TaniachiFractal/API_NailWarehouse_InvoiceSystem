namespace InvoiceSystem.Services.Contracts
{
    /// <summary>
    /// Реализует валидацию
    /// </summary>
    public interface IDBObjectValidationService
    {
        /// <summary>
        /// Валидировать модель 
        /// </summary>
        Task Validate<TModel>(TModel model, CancellationToken cancellationToken);

    }
}
