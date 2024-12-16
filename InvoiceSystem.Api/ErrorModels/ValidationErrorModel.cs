namespace InvoiceSystem.Api.ErrorModels
{
    /// <summary>
    /// Модель ошибки валидации
    /// </summary>
    public class ValidationErrorModel
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        public readonly int ErrorCode = StatusCodes.Status406NotAcceptable;

        /// <summary>
        /// Список ошибок
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Errors { get; set; }
    }
}
