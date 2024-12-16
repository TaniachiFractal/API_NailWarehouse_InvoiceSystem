using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Database.Contracts.DBInterfaces
{
    /// <summary>
    /// Читает из БД
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Получить данные
        /// </summary>
        IQueryable<T> Read<T>() where T : class;
    }
}
