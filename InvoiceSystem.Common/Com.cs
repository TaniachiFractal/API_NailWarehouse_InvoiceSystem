namespace InvoiceSystem.Common
{
    /// <summary>
    /// Общие константы и методы
    /// </summary>
    public static class Com
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

        /// <summary>
        /// Сгенерировать ИНН
        /// </summary>
        public static string NewINN()
            => new Random().NextInt64(999999999999).ToString("D12");

        /// <summary>
        /// Сгенерировать новую строку
        /// </summary>
        public static string NewString(string startPiece)
            => $"{startPiece}{Guid.NewGuid():N}";
    }
}
