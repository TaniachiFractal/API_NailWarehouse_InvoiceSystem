namespace InvoiceSystem.Api.ErrorModels
{
    /// <summary>
    /// Модель ошибки
    /// </summary>
    public class ErrorModel
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message { get; set; }

    }
}
