namespace InvoiceSystem.Common
{
    /// <summary>
    /// Выдаёт время с привязкой к часовому поясу
    /// </summary>
    public interface IDateTimeOffsetProvider
    {
        /// <summary>
        /// Время сейчас в местном часовом поясе
        /// </summary>
        DateTimeOffset Now { get; }

        /// <summary>
        /// Время сейчас на нулевом часовом поясе (Лондон)
        /// </summary>
        DateTimeOffset UtcNow { get; }

        /// <summary>
        /// Случайное время
        /// </summary>
        DateTimeOffset Random { get; }
    }
}
