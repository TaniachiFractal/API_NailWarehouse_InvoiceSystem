using Ahatornn.TestGenerator;
using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Repositories.Invoices;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Repositories.Tests.ReadRepositories
{
    /// <summary>
    /// Тесты <see cref="InvoiceReadRepository"/>
    /// </summary>
    public class InvoiceReadRepositoryTests : BaseReadRepositoryTests<Invoice>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public InvoiceReadRepositoryTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override DbSet<Invoice> DBSet()
            => dBContext.Invoices;

        /// <inheritdoc/>
        protected override Invoice NewDBObject()
            => TestEntityProvider.Shared.Create<Invoice>();

        /// <inheritdoc/>
        protected override IReadRepository<Invoice> Repository()
            => new InvoiceReadRepository(dBContext);
    }
}
