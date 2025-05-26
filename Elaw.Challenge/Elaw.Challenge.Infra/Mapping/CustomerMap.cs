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
            builder.ToTable("TB_CST");

            /* Column names */
            builder.Property(e => e.Id).HasColumnName("CST_ID");
            builder.Property(e => e.AddressId).HasColumnName("ADR_ID");
            builder.Property(e => e.Name).HasColumnName("CST_NAM");
            builder.Property(e => e.Email).HasColumnName("CST_EML");
            builder.Property(e => e.Phone).HasColumnName("CST_PHO"); 
            builder.Property(e => e.CreatedOn).HasColumnName("CRT_ON");
            builder.Property(e => e.DeletedOn).HasColumnName("DLT_ON");
            builder.Property(e => e.ModifiedOn).HasColumnName("MFD_ON");

            builder.Property(e => e.CreatedOn).IsRequired();
            builder.HasIndex(e => e.Email).IsUnique();
        }
    }
}
