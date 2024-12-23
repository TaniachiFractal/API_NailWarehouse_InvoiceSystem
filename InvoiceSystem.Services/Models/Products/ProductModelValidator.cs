﻿using InvoiceSystem.Models.Products;
using InvoiceSystem.Repositories.Contracts.Products;

namespace InvoiceSystem.Services.Models.Products
{
    /// <summary>
    /// Валидатор для <see cref="ProductModel"/>
    /// </summary>
    public class ProductModelValidator : UniqueIdValidator<ProductModel, AddProductModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ProductModelValidator() : base(new AddProductModelValidator())
        {
        }
    }
}
