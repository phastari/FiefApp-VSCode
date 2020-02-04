using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class MarketConfiguration : IEntityTypeConfiguration<Market>
    {
        public void Configure(EntityTypeBuilder<Market> builder)
        {
            builder
                .HasOne(o => o.Assignment)
                .WithOne(p => p.Market)
                .HasForeignKey<Market>(p => p.AssignmentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(m => m.Fief)
                .WithOne(f => f.Market)
                .HasForeignKey<Market>(m => m.FiefId);
        }
    }
}