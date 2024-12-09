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
        void Validate<TModel>(TModel model);

    }
}
