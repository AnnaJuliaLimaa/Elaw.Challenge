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
            builder.ToTable("TB_ADR");

            /* Column names */
            builder.Property(e => e.Id).HasColumnName("ADR_ID");
            builder.Property(e => e.Street).HasColumnName("ADR_STR");
            builder.Property(e => e.City).HasColumnName("ADR_CTY");
            builder.Property(e => e.Number).HasColumnName("ADR_NUM");
            builder.Property(e => e.State).HasColumnName("ADR_STA");
            builder.Property(e => e.ZipCode).HasColumnName("ADR_ZIP");
            builder.Property(e => e.CreatedOn).HasColumnName("CRT_ON");
            builder.Property(e => e.DeletedOn).HasColumnName("DLT_ON");
            builder.Property(e => e.ModifiedOn).HasColumnName("MFD_ON");

            builder.Property(e => e.CreatedOn).IsRequired();
        }
    }
}
