using Elaw.Challenge.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elaw.Challenge.Infra
{
   public sealed class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            /* Table name */
            builder.ToTable("TB_CUSTOMER");

            /* Column names */
            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.AddressId).HasColumnName("ADDRESS_ID");
            builder.Property(e => e.Name).HasColumnName("NAME").IsRequired();
            builder.Property(e => e.Email).HasColumnName("EMAIL").IsRequired();
            builder.Property(e => e.Phone).HasColumnName("PHONE"); 
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.DeletedOn).HasColumnName("DELETED_ON");
            builder.Property(e => e.ModifiedOn).HasColumnName("MODIFIED_ON");

            builder.Property(e => e.CreatedOn).IsRequired();
            builder.HasIndex(e => e.CreatedOn);
            builder.HasIndex(e => e.Email).IsUnique();
        }
    }
}
