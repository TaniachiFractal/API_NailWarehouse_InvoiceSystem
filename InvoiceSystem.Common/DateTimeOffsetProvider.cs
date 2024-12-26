namespace InvoiceSystem.Common
{
    /// <inheritdoc cref="IDateTimeOffsetProvider"/>
    public class DateTimeOffsetProvider : IDateTimeOffsetProvider
    {
        /// <inheritdoc/>
        public DateTimeOffset Now => DateTimeOffset.Now;

        /// <inheritdoc/>
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;


        private Random rnd = new();

        /// <inheritdoc/>
        public DateTimeOffset Random => DateTimeOffset.MinValue.AddDays(rnd.Next());

    }
}
