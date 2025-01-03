﻿namespace InvoiceSystem.Exceptions
{
    /// <summary>
    /// Ошибка валидации
    /// </summary>
    public class ValidationErrorException : InvcSysException
    {
        /// <summary>
        /// Список всех ошибок валидации
        /// </summary>
        public IEnumerable<(string Field, string Message)> Errors { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ValidationErrorException(IEnumerable<(string Field, string Message)> Errors) : base("Model validation error")
        {
            this.Errors = Errors;
        }

    }
}
