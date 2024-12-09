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
    /// dotnet tool install --global dotnet-ef --version 6.0.0
    /// dotnet tool update --global dotnet-ef --version 6.0.0
    /// dotnet ef migrations add InitialCreate --project InvoiceSystem.Database/InvoiceSystem.Database.csproj
    /// dotnet ef database update --project InvoiceSystem.Database/InvoiceSystem.Database.csproj
    /// </remarks>
    public class InvcSysDBContext : DbContext
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
    }
}
