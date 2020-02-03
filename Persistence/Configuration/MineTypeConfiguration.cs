using Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class MineTypeConfiguration : IEntityTypeConfiguration<MineType>
    {
        public void Configure(EntityTypeBuilder<MineType> builder)
        {
            builder.Property(e => e.MineTypeId)
                .HasColumnName("MineTypeId")
                .UseIdentityColumn<int>(1, 1);

            builder
                .HasData(
                    new MineType
                    {
                        MineTypeId = 1,
                        Type = "Tin",
                        DisplayName = "Tenn",
                        SilverProduction = 24000,
                        IronProduction = 0,
                        LuxuryProduction = 0,
                        Crime = 24,
                        PopulationModifier = 72
                    },
                    new MineType
                    {
                        MineTypeId = 2,
                        Type = "Iron",
                        DisplayName = "Järn",
                        SilverProduction = 0,
                        IronProduction = 800,
                        LuxuryProduction = 0,
                        Crime = 40,
                        PopulationModifier = 120
                    },
                    new MineType
                    {
                        MineTypeId = 3,
                        Type = "Copper",
                        DisplayName = "Koppar",
                        SilverProduction = 112800,
                        IronProduction = 0,
                        LuxuryProduction = 10,
                        Crime = 120,
                        PopulationModifier = 360
                    },
                    new MineType
                    {
                        MineTypeId = 4,
                        Type = "Silver",
                        DisplayName = "Silver",
                        SilverProduction = 164000,
                        IronProduction = 0,
                        LuxuryProduction = 50,
                        Crime = 200,
                        PopulationModifier = 600
                    },
                    new MineType
                    {
                        MineTypeId = 5,
                        Type = "Gold",
                        DisplayName = "Guld",
                        SilverProduction = 228000,
                        IronProduction = 0,
                        LuxuryProduction = 100,
                        Crime = 300,
                        PopulationModifier = 900
                    },
                    new MineType
                    {
                        MineTypeId = 6,
                        Type = "Gemstones",
                        DisplayName = "Ädelstenar",
                        SilverProduction = 256000,
                        IronProduction = 0,
                        LuxuryProduction = 200,
                        Crime = 400,
                        PopulationModifier = 1200
                    }
                );
        }
    }
}