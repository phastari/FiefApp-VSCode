using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class BoatConfiguration : IEntityTypeConfiguration<Boat>
    {
        public void Configure(EntityTypeBuilder<Boat> builder)
        {
            builder.Property(e => e.BoatId)
                .HasColumnName("BoatId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Width).HasColumnType("decimal(15,5)");
            builder.Property(e => e.Depth).HasColumnType("decimal(15,5)");
        }
    }
}