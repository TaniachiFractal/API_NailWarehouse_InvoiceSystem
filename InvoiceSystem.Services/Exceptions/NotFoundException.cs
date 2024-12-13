namespace InvoiceSystem.Services.Exceptions
{
    /// <summary>
    /// Ошибка "Не найдено"
    /// </summary>
    public class NotFoundException : DBObjectException
    {
        /// <summary>
        /// Конструктор по ID и названию типа
        /// </summary>
        public NotFoundException(Guid id, string typeName)
            : base($"Ошибка: объект {typeName} с ID {id} не найден.")
        { }

        /// <summary>
        /// Конструктор с сообщением
        /// </summary>
        public NotFoundException(string message)
            : base(message)
        { }
    }
}
