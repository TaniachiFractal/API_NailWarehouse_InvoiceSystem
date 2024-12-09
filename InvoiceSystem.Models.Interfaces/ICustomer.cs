namespace InvoiceSystem.Models.Interfaces
{
    /// <summary>
    /// Имеет поля данных постаащика
    /// </summary>
    public interface ICustomer
    {
        /// <summary>
        /// Название организации
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string INN { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
    }
}
