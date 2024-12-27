using Ahatornn.TestGenerator;
using InvoiceSystem.Common;
using InvoiceSystem.Database.Contracts.Repositories;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Repositories.Products;
using InvoiceSystem.TestsBase;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Repositories.Tests.WriteRepositories
{
    /// <summary>
    /// Тесты <see cref="ProductWriteRepository"/>
    /// </summary>
    public class ProductWriteRepositoryTests : BaseWriteRepositoryTests<Product>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ProductWriteRepositoryTests(DBTestsFixture fixture) : base(fixture)
        {
        }

        /// <inheritdoc/>
        protected override void ChangeOwnFields(Product obj)
        {
            obj.Name = Com.NewString(nameof(obj.Name));
            obj.Price = (decimal)new Random().NextDouble();
        }

        /// <inheritdoc/>
        protected override Product CreateUnboundCopy(Product obj)
        => new()
        {
            Id = obj.Id,
            Name = obj.Name,
            Price = obj.Price,
            CreatedDate = obj.CreatedDate,
            DeletedDate = obj.DeletedDate,
            UpdatedDate = obj.UpdatedDate
        };

        /// <inheritdoc/>
        protected override DbSet<Product> DBSet()
            => dBContext.Products;

        /// <inheritdoc/>
        protected override Product NewDBObject()
            => TestEntityProvider.Shared.Create<Product>();

        /// <inheritdoc/>
        protected override IWriteRepository<Product> Repository()
            => new ProductWriteRepository(dBContext, dateTime, logger);
    }
}
