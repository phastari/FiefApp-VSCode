using Domain.Entities.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class StewardConfiguration : IEntityTypeConfiguration<Steward>
    {
        public void Configure(EntityTypeBuilder<Steward> builder)
        {
            builder
                .HasOne(o => o.Assignment)
                .WithOne(p => p.Steward)
                .HasForeignKey<Steward>(p => p.AssignmentId)
                .IsRequired();
        }
    }
}