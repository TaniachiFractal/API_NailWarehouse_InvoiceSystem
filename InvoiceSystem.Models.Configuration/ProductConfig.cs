using InvoiceSystem.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceSystem.Models.Configuration
{
    /// <summary>
    /// Конфигурация таблицы <see cref="Product"/>
    /// </summary>
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        void IEntityTypeConfiguration<Product>.Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable($"{nameof(Product)}s");

            builder.HasKey(x => x.Id);

            #region Name

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(Cnst.MaxNameLen)
                ;

            builder.HasIndex(x => x.Name)
                .HasDatabaseName(Cnst.IndexFormatString(nameof(Product), nameof(Product.Name)))
                .IsUnique()
                .HasFilter(Cnst.DeletedFilterStr)
                ;

            #endregion

            #region Price

            builder.Property(x => x.Price)
                .IsRequired()
                .HasPrecision(4)
                ;

            #endregion
        }
    }
}
