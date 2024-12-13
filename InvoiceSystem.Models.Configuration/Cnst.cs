using InvoiceSystem.Database.Contracts;

namespace InvoiceSystem.Models.Configuration
{
    /// <summary>
    /// Константы полей таблиц
    /// </summary>
    public static class Cnst
    {
        /// 
        public const int MinLen = 3, MaxNameLen = 255, INNLen = 12, MaxAddressLen = 1023;

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
