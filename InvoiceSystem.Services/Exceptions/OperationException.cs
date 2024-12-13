namespace InvoiceSystem.Services.Exceptions
{
    /// <summary>
    /// Ошибка "Неправильное действие"
    /// </summary>
    public class OperationException : DBObjectException
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public OperationException(string message) : base(message)
        {
        }
    }
}
