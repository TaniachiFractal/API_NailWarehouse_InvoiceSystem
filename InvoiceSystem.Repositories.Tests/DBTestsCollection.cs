using InvoiceSystem.TestsBase;
using Xunit;

namespace InvoiceSystem.Repositories.Tests
{
    /// <inheritdoc cref="ICollectionFixture{TFixture}"/>
    [CollectionDefinition(nameof(DBTestsCollection))]
    public class DBTestsCollection : ICollectionFixture<DBTestsFixture>
    {
    }
}
