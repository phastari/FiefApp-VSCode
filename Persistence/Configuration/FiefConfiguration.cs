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

            builder.Property(e => e.Name).HasMaxLength(60);
            builder.Property(e => e.AnimalHusbandryDevelopmentLevel).HasDefaultValue(1);
            builder.Property(e => e.AgriculturalDevelopmentLevel).HasDefaultValue(1);
            builder.Property(e => e.FishingDevelopmentLevel).HasDefaultValue(1);
            builder.Property(e => e.WoodlandDevelopmentLevel).HasDefaultValue(1);
            builder.Property(e => e.OreDevelopmentLevel).HasDefaultValue(1);
            builder.Property(e => e.EducationDevelopmentLevel).HasDefaultValue(1);
            builder.Property(e => e.HealthcareDevelopmentLevel).HasDefaultValue(1);
            builder.Property(e => e.MilitaryDevelopmentLevel).HasDefaultValue(1);

            builder
                .HasOne(p => p.GameSession)
                .WithMany(b => b.Fiefs)
                .HasForeignKey(c => c.GameSessionId)
                .IsRequired();

            builder
                .HasOne(p => p.Market)
                .WithOne(b => b.Fief)
                .HasForeignKey<Fief>(c => c.MarketId)
                .IsRequired();

            builder
                .HasOne(p => p.Port)
                .WithOne(d => d.Fief)
                .HasForeignKey<Fief>(c => c.PortId);

            builder
                .HasOne(p => p.Livingcondition)
                .WithOne(c => c.Fief)
                .HasForeignKey<Fief>(c => c.LivingconditionId)
                .IsRequired();

            builder
                .HasOne(p => p.Road)
                .WithOne(c => c.Fief)
                .HasForeignKey<Fief>(c => c.RoadId)
                .IsRequired();

            builder
                .HasOne(p => p.Inheritance)
                .WithOne(c => c.Fief)
                .HasForeignKey<Fief>(c => c.InheritanceId)
                .IsRequired();

            builder
                .HasOne(p => p.Assignment)
                .WithOne(p => p.Fief)
                .HasForeignKey<Fief>(p => p.AssignmentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}