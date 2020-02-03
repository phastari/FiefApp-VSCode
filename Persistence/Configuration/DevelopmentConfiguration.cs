using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class DevelopmentConfiguration : IEntityTypeConfiguration<Development>
    {
        public void Configure(EntityTypeBuilder<Development> builder)
        {
            builder
                .HasOne(o => o.Assignment)
                .WithOne(p => p.Development)
                .HasForeignKey<Development>(p => p.AssignmentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}