using Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class QuarryTypeConfiguration : IEntityTypeConfiguration<QuarryType>
    {
        public void Configure(EntityTypeBuilder<QuarryType> builder)
        {
            builder.Property(e => e.QuarryTypeId)
                .HasColumnName("QuarryTypeId")
                .UseIdentityColumn<int>(1, 1);

            builder
                .HasData(
                    new QuarryType
                    {
                        QuarryTypeId = 1,
                        Type = "Small",
                        DisplayName = "Litet",
                        Crime = 6,
                        PopulationModifier = 24
                    },
                    new QuarryType
                    {
                        QuarryTypeId = 2,
                        Type = "Medium",
                        DisplayName = "",
                        Crime = 18,
                        PopulationModifier = 72
                    },
                    new QuarryType
                    {
                        QuarryTypeId = 3,
                        Type = "Large",
                        DisplayName = "Stort",
                        Crime = 54,
                        PopulationModifier = 162
                    }
                );
        }
    }
}