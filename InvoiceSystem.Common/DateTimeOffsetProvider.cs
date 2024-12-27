namespace InvoiceSystem.Common
{
    /// <inheritdoc cref="IDateTimeOffsetProvider"/>
    public class DateTimeOffsetProvider : IDateTimeOffsetProvider
    {
        private readonly Random rnd = new();

        /// <inheritdoc/>
        public DateTimeOffset Now => DateTimeOffset.Now;

        /// <inheritdoc/>
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;

        /// <inheritdoc/>
        public DateTimeOffset Random => DateTimeOffset.MinValue.AddDays(rnd.Next());

    }
}
