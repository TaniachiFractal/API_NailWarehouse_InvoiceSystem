﻿using InvoiceSystem.Database;
using InvoiceSystem.Services.Contracts.Models.Customers;
using InvoiceSystem.TestsBase;
using Xunit;

namespace InvoiceSystem.Services.Tests
{
    /// <inheritdoc cref="ICollectionFixture{TFixture}"/>
    [CollectionDefinition(nameof(DBTestsCollection))]
    public class DBTestsCollection : ICollectionFixture<DBTestsFixture>
    {
    }
}