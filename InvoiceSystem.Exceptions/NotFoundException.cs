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
            : base($"Ошибка: объект типа {type.Name} с ID {id} не найден.")
        { }

        /// <summary>
        /// Конструктор с сообщением
        /// </summary>
        public NotFoundException(string message)
            : base(message)
        { }
    }
}
