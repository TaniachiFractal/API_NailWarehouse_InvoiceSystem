using InvoiceSystem.Api.ErrorModels;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Api.ResponseAttributes
{
    /// <summary>
    /// Может выдавать ошибку валидации
    /// </summary>
    public class ProducesValidationErrorAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ProducesValidationErrorAttribute() : base(typeof(ValidationErrorModel), StatusCodes.Status406NotAcceptable)
        {
        }
    }
}
