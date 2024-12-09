using InvoiceSystem.Models.Customers;
using InvoiceSystem.Models.Invoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceSystem.Models.Configuration
{
    /// <summary>
    /// Конфигурация таблицы <see cref="Invoice"/>
    /// </summary>
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        void IEntityTypeConfiguration<Invoice>.Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable($"{nameof(Invoice)}s");

            builder.HasKey(x => x.Id);

            #region CustomerId

            builder.Property(x => x.CustomerId)
                .IsRequired()
                ;

            builder.HasOne<Customer>()
               .WithMany()
               .HasForeignKey(i => i.CustomerId)
               ;

            #endregion

            #region ExecutionDate

            builder.Property(x => x.ExecutionDate)
                .IsRequired()
                ;

            #endregion

        }
    }
}
