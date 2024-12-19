using InvoiceSystem.Database.Contracts.ModelInterfaces;

namespace InvoiceSystem.Models.Configuration
{
    /// <summary>
    /// Константы полей таблиц
    /// </summary>
    public static class Cnst
    {
        /// <summary>
        /// Минимальная длина строки
        /// </summary>
        public const int MinLen = 3;

        /// <summary>
        /// Максимальная длина названия
        /// </summary>
        public const int MaxNameLen = 255;

        /// <summary>
        /// Длина ИНН
        /// </summary>
        public const int INNLen = 12;

        /// <summary>
        /// Максимальная длина адреса
        /// </summary>
        public const int MaxAddressLen = 1023;

        /// <summary>
        /// Строка фильтра удалённого объекта
        /// </summary>
        public readonly static string DeletedFilterStr = $"{nameof(ISoftDeleted.DeletedDate)} is null";

        /// <returns>Строку названия индекса по шаблону</returns>
        public static string IndexFormatString(string field)
        {
            return $"IX_{field}_{nameof(ISoftDeleted.DeletedDate)}";
        }
    }
}
