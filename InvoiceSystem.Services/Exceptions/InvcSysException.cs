namespace InvoiceSystem.Services.Exceptions
{
    /// <summary>
    /// Ошибки системы накладных
    /// </summary>
    public abstract class InvcSysException : Exception
    {
        /// <summary>
        /// Конструктор ошибки
        /// </summary>
        /// <param name="message"></param>
        public InvcSysException(string message) : base(message) { }
    }
}
