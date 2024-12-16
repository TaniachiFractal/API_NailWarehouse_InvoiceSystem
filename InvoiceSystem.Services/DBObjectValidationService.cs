using FluentValidation;
using InvoiceSystem.Database.Contracts.ModelInterfaces;
using InvoiceSystem.Services.Contracts;
using InvoiceSystem.Services.Exceptions;

namespace InvoiceSystem.Services
{
    /// <summary>
    /// Стандартный сервис валидации
    /// </summary>
    public class DBObjectValidationService
        <TObjectModel, TAddObjectModel, TObjectModelValidator, TAddObjectModelValidator> : IDBObjectValidationService
        where TObjectModel : IUniqueID, TAddObjectModel
        where TObjectModelValidator : AbstractValidator<TObjectModel>, new()
        where TAddObjectModelValidator : AbstractValidator<TAddObjectModel>, new()
    {
        private readonly Dictionary<Type, IValidator> validators = new();

        /// <summary>
        /// Конструтор
        /// </summary>
        public DBObjectValidationService()
        {
            validators.Add(typeof(TObjectModel), new TObjectModelValidator());
            validators.Add(typeof(TAddObjectModel), new TAddObjectModelValidator());
        }

        void IDBObjectValidationService.Validate<TModel>(TModel model)
        {
            var modelType = typeof(TModel);
            if (validators.TryGetValue(modelType, out var validator))
            {
                var context = new ValidationContext<TModel>(model);
                var result = validator.Validate(context);
                if (!result.IsValid)
                {
                    throw new ValidationErrorException(result.Errors.Select(x => (x.PropertyName, x.ErrorMessage)));
                }
            }
            else
            {
                throw new OperationException("Нет валидатора");
            }
        }

    }
}
