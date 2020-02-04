using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class PortConfiguration : IEntityTypeConfiguration<Port>
    {
        public void Configure(EntityTypeBuilder<Port> builder)
        {
            builder
                .HasOne(p => p.Fief)
                .WithOne(b => b.Port)
                .HasForeignKey<Port>(c => c.FiefId);

            builder
                .HasOne(p => p.Assignment)
                .WithOne(p => p.Port)
                .HasForeignKey<Port>(c => c.AssignmentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}