using InvoiceSystem.Api.ErrorModels;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Api.ResponseAttributes
{
    /// <summary>
    /// Может выдавать ошибку "Не найдено"
    /// </summary>
    public class ProducesNotFoundAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ProducesNotFoundAttribute() : base(typeof(ErrorModel), StatusCodes.Status404NotFound)
        {
        }
    }
}
