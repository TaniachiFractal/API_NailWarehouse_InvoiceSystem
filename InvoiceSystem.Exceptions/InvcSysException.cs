namespace InvoiceSystem.Exceptions
{
    /// <summary>
    /// Ошибки системы накладных
    /// </summary>
    public abstract class InvcSysException : Exception
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public InvcSysException(string message) : base(message)
        { }
    }
}
