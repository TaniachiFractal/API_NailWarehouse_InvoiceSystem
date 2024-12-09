namespace InvoiceSystem.Services.Exceptions
{
    /// <summary>
    /// Ошибки моделей БД
    /// </summary>
    public abstract class DBObjectException : Exception
    {
        /// <summary>
        /// Конструктор ошибки
        /// </summary>
        /// <param name="message"></param>
        public DBObjectException(string message) : base(message) { }
    }
}
