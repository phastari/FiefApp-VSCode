using Domain.Entities.Industries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class IndustryConfiguration : IEntityTypeConfiguration<Industry>
    {
        public void Configure(EntityTypeBuilder<Industry> builder)
        {
            builder
                .HasOne(o => o.Assignment)
                .WithOne(p => p.Industry)
                .HasForeignKey<Industry>(p => p.AssignmentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}