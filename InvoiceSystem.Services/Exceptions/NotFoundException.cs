using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.Exceptions
{
    /// <summary>
    /// Ошибка "Не найдено"
    /// </summary>
    public class NotFoundException : DBObjectException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
