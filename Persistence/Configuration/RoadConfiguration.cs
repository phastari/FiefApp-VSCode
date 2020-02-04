using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class RoadConfiguration : IEntityTypeConfiguration<Road>
    {
        public void Configure(EntityTypeBuilder<Road> builder)
        {
            builder
                .HasOne(r => r.Fief)
                .WithOne(f => f.Road)
                .HasForeignKey<Road>(r => r.FiefId);
        }
    }
}