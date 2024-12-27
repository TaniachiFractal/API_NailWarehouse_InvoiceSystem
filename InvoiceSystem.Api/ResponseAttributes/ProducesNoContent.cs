using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Api.ResponseAttributes
{
    /// <summary>
    /// Может выдавать ответ без начинки
    /// </summary>
    public class ProducesNoContent : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ProducesNoContent() : base(StatusCodes.Status204NoContent)
        {
        }
    }
}
