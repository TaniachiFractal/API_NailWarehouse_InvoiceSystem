using InvoiceSystem.Database.Contracts.ModelInterfaces;

namespace InvoiceSystem.Models.Configuration
{
    /// <summary>
    /// Форматирование строк
    /// </summary>
    public static class StringFormaters
    {
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
