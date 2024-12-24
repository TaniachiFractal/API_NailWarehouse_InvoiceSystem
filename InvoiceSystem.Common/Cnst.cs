namespace InvoiceSystem.Common
{
    /// <summary>
    /// Общие константы
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
        /// Строка подключения к БД
        /// </summary>
        public const string DBConString = "Server=(localdb)\\mssqllocaldb;Database=MaslovaInvoiceSystem;Trusted_Connection=True;";
    }
}
