﻿using FluentValidation;
using InvoiceSystem.Database.Contracts.ModelInterfaces;

namespace InvoiceSystem.Services
{
    /// <summary>
    /// Стандартный валидатор для <see cref="IUniqueID"/>
    /// </summary>
    public class UniqueIdValidator<TObjectModel, TAddObjectModel> : AbstractValidator<TObjectModel>
        where TObjectModel : IUniqueID, TAddObjectModel
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public UniqueIdValidator(AbstractValidator<TAddObjectModel> addObjectModelValidator)
        {
            Include((IValidator<TObjectModel>)addObjectModelValidator);
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
