using Domain.Entities;
using Domain.Entities.Industries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder
                .HasOne(o => o.Industry)
                .WithOne(p => p.Assignment)
                .HasForeignKey<Industry>(p => p.AssignmentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(o => o.Development)
                .WithOne(p => p.Assignment)
                .HasForeignKey<Development>(p => p.AssignmentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(o => o.Fief)
                .WithOne(p => p.Assignment)
                .HasForeignKey<Fief>(p => p.AssignmentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(o => o.Market)
                .WithOne(p => p.Assignment)
                .HasForeignKey<Market>(p => p.AssignmentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(o => o.Port)
                .WithOne(p => p.Assignment)
                .HasForeignKey<Port>(p => p.AssignmentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(o => o.Shipyard)
                .WithOne(p => p.Assignment)
                .HasForeignKey<Shipyard>(p => p.AssignmentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}