using InvoiceSystem.Database.Contracts;

namespace InvoiceSystem.Models.Configuration
{
    static internal class Cnst
    {
        public const int MaxNameLen = 255, INNLen = 12, MaxAddressLen = 1023;
        public readonly static string DeletedFilterStr = $"{nameof(ISoftDeleted.DeletedDate)} is null";

        private readonly static string indexFormatStr = $"IX_{0}_{1}_{nameof(ISoftDeleted.DeletedDate)}";

        /// <returns>Строку названия индекса по шаблону</returns>
        public static string IndexFormatString(string table, string field)
        {
            return string.Format(indexFormatStr, table, field);
        }
    }
}
