using InvoiceSystem.Common;
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

            builder.HasKey(x => x.Id);

            #region Name

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(Cnst.MaxNameLen)
                ;

            builder.HasIndex(x => x.Name)
                .HasDatabaseName(StringFormaters.IndexFormatString(nameof(Customer.Name)))
                .HasFilter(StringFormaters.DeletedFilterStr)
                ;

            #endregion

            #region INN

            builder.Property(x => x.INN)
                .IsRequired()
                .HasMaxLength(Cnst.INNLen)
                .IsFixedLength()
                ;

            builder.HasIndex(x => x.INN)
                .HasDatabaseName(StringFormaters.IndexFormatString(nameof(Customer.INN)))
                .IsUnique()
                .HasFilter(StringFormaters.DeletedFilterStr)
                ;

            #endregion

            #region Address

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(Cnst.MaxAddressLen)
                ;

            #endregion

        }
    }
}
