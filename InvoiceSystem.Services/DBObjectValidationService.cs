using FluentValidation;
using InvoiceSystem.Exceptions;
using InvoiceSystem.Services.Contracts;

namespace InvoiceSystem.Services
{
    /// <summary>
    /// Стандартный сервис валидации
    /// </summary>
    public abstract class DBObjectValidationService : IDBObjectValidationService
    {
        /// <summary>
        /// Список валидаторов
        /// </summary>
        readonly protected Dictionary<Type, IValidator> validators = new();

        /// <summary>
        /// Конструтор
        /// </summary>
        public DBObjectValidationService()
        {
        }

        async Task IDBObjectValidationService.Validate<TModel>(TModel model, CancellationToken cancellationToken)
        {
            var modelType = typeof(TModel);
            if (validators.TryGetValue(modelType, out var validator))
            {
                var context = new ValidationContext<TModel>(model);
                var result = await validator.ValidateAsync(context, cancellationToken);
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
