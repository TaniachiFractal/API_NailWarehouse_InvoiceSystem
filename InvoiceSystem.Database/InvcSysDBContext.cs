using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Configuration;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Database
{
    /// <summary>
    /// Контекст базы данных системы накладных
    /// </summary>
    /// <remarks>
    /// https://learn.microsoft.com/ru-ru/ef/core/cli/dotnet
    /// <para> dotnet tool install --global dotnet-ef --version 6.0.0 </para>
    /// <para> dotnet tool update --global dotnet-ef --version 6.0.0 </para>
    /// <para> dotnet ef migrations add InitialCreate --project InvoiceSystem.Database/InvoiceSystem.Database.csproj </para>
    /// <para> dotnet ef database update --project InvoiceSystem.Database/InvoiceSystem.Database.csproj </para>
    /// </remarks>
    public class InvcSysDBContext : DbContext, IReader, IWriter, IUnitOfWork
    {
        /// <summary>
        /// Таблица <see cref="Customer"/>s
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Таблица <see cref="Product"/>s
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Таблица <see cref="Invoice"/>s
        /// </summary>
        public DbSet<Invoice> Invoices { get; set; }

        /// <summary>
        /// Таблица <see cref="Sale"/>s
        /// </summary>
        public DbSet<Sale> Sales { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public InvcSysDBContext(DbContextOptions<InvcSysDBContext> options) : base(options)
        {

        }

        /// <summary>
        /// При генерации модели указать сборку с конфигурацией таблиц
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IModelConfigAnchor).Assembly);
        }

        IQueryable<T> IReader.Read<T>()
            => base.Set<T>()
            .AsQueryable()
            .AsNoTracking();

        void IWriter.Add<T>(T entity)
        => base.Entry(entity).State = EntityState.Added;

        void IWriter.Delete<T>(T entity)
        => base.Entry(entity).State = EntityState.Deleted;

        void IWriter.Update<T>(T entity)
        => base.Entry(entity).State = EntityState.Modified;

        async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            var count = await base.SaveChangesAsync(cancellationToken);
            foreach (var entry in base.ChangeTracker.Entries().ToArray())
            {
                entry.State = EntityState.Detached;
            }
            return count;
        }
    }
}
