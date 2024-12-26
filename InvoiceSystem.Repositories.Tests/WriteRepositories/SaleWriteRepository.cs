using Ahatornn.TestGenerator;
using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Sales;
using InvoiceSystem.Repositories.Sales;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Repositories.Tests.WriteRepositories
{
    /// <summary>
    /// Тесты <see cref="SaleWriteRepository"/>
    /// </summary>
    public class SaleWriteRepositoryTests : BaseWriteRepositoryTests<Sale>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public SaleWriteRepositoryTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override void ChangeOwnFields(Sale obj)
        {
            obj.ProductId = Guid.NewGuid();
            obj.InvoiceId = Guid.NewGuid();
            obj.SoldCount = new Random().Next();
        }

        /// <inheritdoc/>
        protected override Sale CreateUnboundCopy(Sale obj)
        => new()
        {
            Id = obj.Id,
            ProductId = obj.ProductId,
            InvoiceId = obj.InvoiceId,
            SoldCount = obj.SoldCount,
            CreatedDate = obj.CreatedDate,
            DeletedDate = obj.DeletedDate,
            UpdatedDate = obj.UpdatedDate
        };

        /// <inheritdoc/>
        protected override DbSet<Sale> DBSet()
            => dBContext.Sales;

        /// <inheritdoc/>
        protected override Sale NewDBObject()
            => TestEntityProvider.Shared.Create<Sale>();

        /// <inheritdoc/>
        protected override IWriteRepository<Sale> Repository()
            => new SaleWriteRepository(dBContext, dateTime);
    }
}
