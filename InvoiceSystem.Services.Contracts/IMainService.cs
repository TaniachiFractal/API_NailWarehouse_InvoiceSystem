﻿using InvoiceSystem.Models;

namespace InvoiceSystem.Services.Contracts
{
    /// <summary>
    /// Главный сервис
    /// </summary>
    public interface IMainService
    {
        /// <summary>
        /// Получить все данные для накладной из нескольких таблиц
        /// </summary>
        Task<FullInvoiceInfoModel> GetFullInvoiceInfo(Guid invoiceId, CancellationToken cancellationToken);

    }
}
