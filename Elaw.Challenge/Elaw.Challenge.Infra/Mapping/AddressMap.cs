using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Elaw.Challenge.Domain;

namespace Elaw.Challenge.Infra
{
    public sealed class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            /* Table name */
            builder.ToTable("TB_ADDRESS");

            /* Column names */
            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.Street).HasColumnName("STREET");
            builder.Property(e => e.City).HasColumnName("CITY");
            builder.Property(e => e.Number).HasColumnName("NUMBER"); 
            builder.Property(e => e.State).HasColumnName("STATE");
            builder.Property(e => e.ZipCode).HasColumnName("ZIPCODE");
            builder.Property(e => e.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(e => e.DeletedOn).HasColumnName("DELETED_ON");
            builder.Property(e => e.ModifiedOn).HasColumnName("MODIFIED_ON");

            builder.Property(e => e.CreatedOn).IsRequired();
            builder.HasIndex(e => e.CreatedOn);
        }
    }
}
