using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class FiefConfiguration : IEntityTypeConfiguration<Fief>
    {
        public void Configure(EntityTypeBuilder<Fief> builder)
        {
            builder.Property(e => e.FiefId)
                .HasColumnName("FiefId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasMaxLength(60).HasDefaultValue("Ny förläning");
            builder.Property(e => e.AnimalHusbandryDevelopmentLevel).HasDefaultValue(1);
            builder.Property(e => e.AgriculturalDevelopmentLevel).HasDefaultValue(1);
            builder.Property(e => e.FishingDevelopmentLevel).HasDefaultValue(1);
            builder.Property(e => e.WoodlandDevelopmentLevel).HasDefaultValue(1);
            builder.Property(e => e.OreDevelopmentLevel).HasDefaultValue(1);
            builder.Property(e => e.EducationDevelopmentLevel).HasDefaultValue(1);
            builder.Property(e => e.HealthcareDevelopmentLevel).HasDefaultValue(1);
            builder.Property(e => e.MilitaryDevelopmentLevel).HasDefaultValue(1);
            builder.Property(e => e.SeafaringDevelopmentLevel).HasDefaultValue(1);

            builder
                .HasOne(p => p.GameSession)
                .WithMany(b => b.Fiefs)
                .HasForeignKey(c => c.GameSessionId)
                .IsRequired();

            builder
                .HasOne(p => p.Assignment)
                .WithOne(p => p.Fief)
                .HasForeignKey<Fief>(p => p.AssignmentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}