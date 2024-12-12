namespace InvoiceSystem.Services.Exceptions
{
    /// <summary>
    /// Ошибка "Не найдено"
    /// </summary>
    public class NotFoundException : DBObjectException
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public NotFoundException(Guid id, string typeName)
            : base($"Ошибка: объект {typeName} с id {id} не найден.")
        {
        }
    }
}
