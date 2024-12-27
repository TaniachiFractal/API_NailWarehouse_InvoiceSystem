using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceSystem.Models.Configuration
{
    /// <summary>
    /// Конфигурация таблицы <see cref="Sale"/>
    /// </summary>
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        void IEntityTypeConfiguration<Sale>.Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable($"{nameof(Sale)}s");

            builder.HasKey(x => x.Id);

            #region ProductId

            builder.Property(x => x.ProductId)
                .IsRequired()
                ;

            builder.HasOne<Product>()
               .WithMany()
               .HasForeignKey(i => i.ProductId)
               ;

            #endregion

            #region InvoiceId

            builder.Property(x => x.InvoiceId)
                .IsRequired()
                ;

            builder.HasOne<Invoice>()
               .WithMany()
               .HasForeignKey(i => i.InvoiceId)
               ;

            #endregion

        }
    }
}
