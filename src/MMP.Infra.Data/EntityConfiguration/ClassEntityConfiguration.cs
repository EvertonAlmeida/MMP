using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMP.Domain.Models.Classes;

namespace MMP.Infra.Data.EntityConfiguration
{
    public class ClassEntityConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(e => e.Title)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.Value)
            .HasColumnType("decimal(18,2)");

            builder.Property(e => e.CompanyName)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.HasOne(e => e.ClassType)
                .WithMany(e => e.Classes)
                .HasForeignKey(e => e.ClassTypeId);

            builder.HasOne(e => e.Venue)
                .WithMany(e => e.Classes)
                .HasForeignKey(e => e.VenueId);

            builder.ToTable("Classes");
        }
    }
}