namespace InvoiceSystem.Api.Infrastructure
{
    /// <summary>
    /// Промежуточный слой добавления автора
    /// </summary>
    public class AuthorMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// Конструктор
        /// </summary>
        public AuthorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Выполнить добавление заголовка
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("Author", "Taniachi Fractal");
            await next(context);
        }
    }
}
