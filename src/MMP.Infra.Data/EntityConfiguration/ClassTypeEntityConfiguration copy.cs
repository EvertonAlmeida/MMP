using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMP.Domain.Models.Classes;

namespace MMP.Infra.Data.EntityConfiguration
{
    public class ClassTypeEntityConfiguration : IEntityTypeConfiguration<ClassType>
    {
        public void Configure(EntityTypeBuilder<ClassType> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(e => e.Title)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.ToTable("ClassTypes");
        }
    }
}