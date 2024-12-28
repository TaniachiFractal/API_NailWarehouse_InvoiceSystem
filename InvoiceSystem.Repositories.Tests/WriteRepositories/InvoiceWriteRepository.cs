using Ahatornn.TestGenerator;
using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Repositories.Invoices;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Repositories.Tests.WriteRepositories
{
    /// <summary>
    /// Тесты <see cref="InvoiceWriteRepository"/>
    /// </summary>
    public class InvoiceWriteRepositoryTests : BaseWriteRepositoryTests<Invoice>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public InvoiceWriteRepositoryTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override void ChangeOwnFields(Invoice obj)
        {
            obj.CustomerId = Guid.NewGuid();
            obj.ExecutionDate = dateTime.UtcNow.Date;
        }

        /// <inheritdoc/>
        protected override Invoice CreateUnboundCopy(Invoice obj)
        => new()
        {
            Id = obj.Id,
            CustomerId = obj.CustomerId,
            ExecutionDate = obj.ExecutionDate,
            CreatedDate = obj.CreatedDate,
            DeletedDate = obj.DeletedDate,
            UpdatedDate = obj.UpdatedDate
        };

        /// <inheritdoc/>
        protected override DbSet<Invoice> DBSet()
            => dBContext.Invoices;

        /// <inheritdoc/>
        protected override Invoice NewDBObject()
            => TestEntityProvider.Shared.Create<Invoice>();

        /// <inheritdoc/>
        protected override IWriteRepository<Invoice> Repository()
            => new InvoiceWriteRepository(dBContext, dateTime, logger);
    }
}
