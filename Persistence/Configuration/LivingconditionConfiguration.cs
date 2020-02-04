using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class LivingconditionConfiguration : IEntityTypeConfiguration<Livingcondition>
    {
        public void Configure(EntityTypeBuilder<Livingcondition> builder)
        {
            builder
                .HasOne(o => o.Fief)
                .WithOne(p => p.Livingcondition)
                .HasForeignKey<Livingcondition>(p => p.FiefId);
        }
    }
}