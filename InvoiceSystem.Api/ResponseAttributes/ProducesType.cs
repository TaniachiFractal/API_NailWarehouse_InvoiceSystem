using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Api.ResponseAttributes
{
    /// <summary>
    /// Может выдавать структуру данных класса
    /// </summary>
    public class ProducesType : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ProducesType(Type type) : base(type, StatusCodes.Status200OK)
        {
        }
    }
}
