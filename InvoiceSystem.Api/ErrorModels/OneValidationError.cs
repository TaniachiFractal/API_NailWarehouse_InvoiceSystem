namespace InvoiceSystem.Api.ErrorModels
{
    /// <summary>
    /// Кортеж названия поля и описания ошибки
    /// </summary>
    public class OneValidationError
    {
        /// <summary>
        /// Название поля
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public OneValidationError(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }
}
