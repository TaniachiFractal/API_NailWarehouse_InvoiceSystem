﻿using InvoiceSystem.Database.Contracts.ModelInterfaces;

namespace InvoiceSystem.Models.Products
{
    /// <summary>
    /// Модель просмотра данных товара
    /// </summary>
    public class ProductModel : AddProductModel, IUniqueID
    {
        Guid IUniqueID.Id { get; set; }
    }
}
