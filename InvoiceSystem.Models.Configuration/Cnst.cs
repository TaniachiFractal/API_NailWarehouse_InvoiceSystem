using InvoiceSystem.Database.Contracts;

namespace InvoiceSystem.Models.Configuration
{
    static internal class Cnst
    {
        public const int MaxNameLen = 255, INNLen = 12, MaxAddressLen = 1023;
        public readonly static string DeletedFilterStr = $"{nameof(ISoftDeleted.DeletedDate)} is null";

        /// <returns>Строку названия индекса по шаблону</returns>
        public static string IndexFormatString(string field)
        {
            return $"IX_{field}_{nameof(ISoftDeleted.DeletedDate)}";
        }
    }
}
