namespace InvoiceSystem.Exceptions
{
    /// <summary>
    /// Ошибка "Не найдено"
    /// </summary>
    public class NotFoundException : InvcSysException
    {
        /// <summary>
        /// Конструктор по ID и названию типа
        /// </summary>
        public NotFoundException(Guid id, Type type)
            : base($"Object of {type.Name} with ID {id} not found.")
        { }

        /// <summary>
        /// Конструктор с сообщением
        /// </summary>
        public NotFoundException(string message)
            : base(message)
        { }
    }
}
