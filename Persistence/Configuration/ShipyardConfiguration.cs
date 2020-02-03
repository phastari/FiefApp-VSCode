using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ShipyardConfiguration : IEntityTypeConfiguration<Shipyard>
    {
        public void Configure(EntityTypeBuilder<Shipyard> builder)
        {
            builder
                .HasOne(o => o.Assignment)
                .WithOne(p => p.Shipyard)
                .HasForeignKey<Shipyard>(p => p.AssignmentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}