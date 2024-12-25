using FluentValidation;
using InvoiceSystem.Database;
using InvoiceSystem.TestsBase;
using Xunit;

namespace InvoiceSystem.Services.Tests.Validators
{
    /// <summary>
    /// База для тестов валидаторов
    /// </summary>
    [Collection(nameof(DBTestsCollection))]
    public abstract class BaseValidatorTests<TModel> where TModel : class, new()
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        readonly protected InvcSysDBContext dBContext;
        /// <summary>
        /// Валидатор
        /// </summary>
        protected AbstractValidator<TModel>? validator;

        private readonly CancellationToken cancellationToken;

        /// <summary>
        /// Конструктор
        /// </summary>
        public BaseValidatorTests(DBTestsFixture fixture)
        {
            dBContext = fixture.DbContext;
            cancellationToken = fixture.CancellationToken;
        }
    }
}
