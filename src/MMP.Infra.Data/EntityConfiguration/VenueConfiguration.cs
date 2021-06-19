using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMP.Domain.Models.Classes;

namespace MMP.Infra.Data.EntityConfiguration
{
    public class VenueEntityConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(e => e.Name)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(e => e.Address)
                .HasColumnType("varchar(350)");

            builder.Property(e => e.ContactNumber)
                .HasColumnType("varchar(15)")
                .IsRequired();

              builder.Property(e => e.Url)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.ToTable("Venues");
        }
    }
}