using InvoiceSystem.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceSystem.Models.Configuration
{
    /// <summary>
    /// Конфигурация таблицы <see cref="Customer"/>
    /// </summary>
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        void IEntityTypeConfiguration<Customer>.Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable($"{nameof(Customer)}s");
        }
    }
}
