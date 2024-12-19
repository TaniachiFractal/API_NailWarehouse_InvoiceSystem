namespace InvoiceSystem.Exceptions
{
    /// <summary>
    /// Ошибка "Неправильное действие"
    /// </summary>
    public class OperationException : InvcSysException
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public OperationException(string message) : base(message)
        {
        }
    }
}
