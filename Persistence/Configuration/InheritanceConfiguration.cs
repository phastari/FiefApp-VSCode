using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class InheritanceConfiguration : IEntityTypeConfiguration<Inheritance>
    {
        public void Configure(EntityTypeBuilder<Inheritance> builder)
        {
            builder
                .HasOne(o => o.Fief)
                .WithOne(p => p.Inheritance)
                .HasForeignKey<Inheritance>(p => p.FiefId);
        }
    }
}