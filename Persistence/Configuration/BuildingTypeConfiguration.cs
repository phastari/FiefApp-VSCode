using Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class BuildingTypeConfiguration : IEntityTypeConfiguration<BuildingType>
    {
        public void Configure(EntityTypeBuilder<BuildingType> builder)
        {
            builder
                .Property(e => e.BuildingTypeId)
                .HasColumnName("BuildingTypeId")
                .UseIdentityColumn<int>(1, 1);

            builder.HasData(
                new BuildingType
                {
                    BuildingTypeId = 1,
                    Type = "Bageri",
                    Upkeep = 3,
                    Woodwork = 920,
                    Stonework = 280,
                    Smithswork = 0,
                    Wood = 60,
                    Stone = 14,
                    Iron = 0
                },
                new BuildingType
                {
                    BuildingTypeId = 2,
                    Type = "Kvarn",
                    Woodwork = 1533,
                    Stonework = 540,
                    Smithswork = 8,
                    Iron = 8,
                    Stone = 27,
                    Wood = 100,
                    Upkeep = 4
                },
                new BuildingType
                {
                    BuildingTypeId = 3,
                    Type = "Vall",
                    Woodwork = 0,
                    Stonework = 40,
                    Smithswork = 0,
                    Iron = 0,
                    Stone = 0,
                    Wood = 0,
                    Upkeep = 0.1
                },
                new BuildingType
                {
                    BuildingTypeId = 4,
                    Type = "Vall och grav",
                    Woodwork = 0,
                    Stonework = 60,
                    Smithswork = 0,
                    Iron = 0,
                    Stone = 0,
                    Wood = 0,
                    Upkeep = 0.2
                },
                new BuildingType
                {
                    BuildingTypeId = 5,
                    Type = "Palissad",
                    Woodwork = 20,
                    Stonework = 0,
                    Smithswork = 0,
                    Iron = 0,
                    Stone = 0,
                    Wood = 5,
                    Upkeep = 0.1
                },
                new BuildingType
                {
                    BuildingTypeId = 6,
                    Type = "Dubbel palissad",
                    Woodwork = 60,
                    Stonework = 0,
                    Smithswork = 0,
                    Iron = 0,
                    Stone = 0,
                    Wood = 15,
                    Upkeep = 0.2
                },
                new BuildingType
                {
                    BuildingTypeId = 7,
                    Type = "Mur",
                    Woodwork = 53,
                    Stonework = 1100,
                    Smithswork = 0,
                    Iron = 0,
                    Stone = 53,
                    Wood = 0,
                    Upkeep = 0.4
                },
                new BuildingType
                {
                    BuildingTypeId = 8,
                    Type = "Dubbel mur",
                    Woodwork = 150,
                    Stonework = 3000,
                    Smithswork = 0,
                    Iron = 0,
                    Stone = 150,
                    Wood = 100,
                    Upkeep = 0.6
                },
                new BuildingType
                {
                    BuildingTypeId = 9,
                    Type = "Tjock mur",
                    Woodwork = 750,
                    Stonework = 5000,
                    Smithswork = 0,
                    Iron = 0,
                    Stone = 750,
                    Wood = 0,
                    Upkeep = 0.8
                },
                new BuildingType
                {
                    BuildingTypeId = 10,
                    Type = "Massiv mur",
                    Woodwork = 4000,
                    Stonework = 35000,
                    Smithswork = 0,
                    Iron = 0,
                    Stone = 4000,
                    Wood = 0,
                    Upkeep = 1
                },
                new BuildingType
                {
                    BuildingTypeId = 11,
                    Type = "Mur med stävpelare",
                    Woodwork = 58,
                    Stonework = 1200,
                    Smithswork = 0,
                    Iron = 0,
                    Stone = 58,
                    Wood = 0,
                    Upkeep = 0.45
                },
                new BuildingType
                {
                    BuildingTypeId = 12,
                    Type = "Litet porttorn",
                    Woodwork = 92,
                    Stonework = 1400,
                    Smithswork = 12,
                    Iron = 12,
                    Stone = 68,
                    Wood = 6,
                    Upkeep = 1
                },
                new BuildingType
                {
                    BuildingTypeId = 13,
                    Type = "Porttorn",
                    Woodwork = 270,
                    Stonework = 4400,
                    Smithswork = 24,
                    Iron = 24,
                    Stone = 220,
                    Wood = 12,
                    Upkeep = 2
                },
                new BuildingType
                {
                    BuildingTypeId = 14,
                    Type = "Stort porttorn",
                    Woodwork = 1500,
                    Stonework = 28000,
                    Smithswork = 42,
                    Iron = 24,
                    Stone = 220,
                    Wood = 21,
                    Upkeep = 4
                },
                new BuildingType
                {
                    BuildingTypeId = 15,
                    Type = "Trätorn",
                    Woodwork = 88,
                    Stonework = 0,
                    Smithswork = 44,
                    Iron = 44,
                    Stone = 0,
                    Wood = 22,
                    Upkeep = 1
                },
                new BuildingType
                {
                    BuildingTypeId = 16,
                    Type = "Litet stentorn, fyrkantigt",
                    Woodwork = 110,
                    Stonework = 1700,
                    Smithswork = 12,
                    Iron = 12,
                    Stone = 87,
                    Wood = 6,
                    Upkeep = 1
                },
                new BuildingType
                {
                    BuildingTypeId = 17,
                    Type = "Stentorn, fyrkantigt",
                    Woodwork = 370,
                    Stonework = 5400,
                    Smithswork = 52,
                    Iron = 52,
                    Stone = 270,
                    Wood = 26,
                    Upkeep = 2
                },
                new BuildingType
                {
                    BuildingTypeId = 18,
                    Type = "Stort stentorn, fyrkantigt",
                    Woodwork = 1600,
                    Stonework = 30000,
                    Smithswork = 80,
                    Iron = 80,
                    Stone = 1500,
                    Wood = 40,
                    Upkeep = 4
                },
                new BuildingType
                {
                    BuildingTypeId = 19,
                    Type = "Litet stentorn, runt",
                    Woodwork = 88,
                    Stonework = 1300,
                    Smithswork = 8,
                    Iron = 8,
                    Stone = 63,
                    Wood = 4,
                    Upkeep = 1
                },
                new BuildingType
                {
                    BuildingTypeId = 20,
                    Type = "Stentorn, runt",
                    Woodwork = 290,
                    Stonework = 4200,
                    Smithswork = 42,
                    Iron = 42,
                    Stone = 210,
                    Wood = 21,
                    Upkeep = 2
                },
                new BuildingType
                {
                    BuildingTypeId = 21,
                    Type = "Stort stentorn, runt",
                    Woodwork = 1250,
                    Stonework = 23500,
                    Smithswork = 60,
                    Iron = 60,
                    Stone = 1175,
                    Wood = 31,
                    Upkeep = 4
                },
                new BuildingType
                {
                    BuildingTypeId = 22,
                    Type = "Borgkärna, fyrkantig",
                    Woodwork = 2500,
                    Stonework = 44000,
                    Smithswork = 160,
                    Iron = 160,
                    Stone = 2200,
                    Wood = 74,
                    Upkeep = 8
                },
                new BuildingType
                {
                    BuildingTypeId = 23,
                    Type = "Stor borgkärna, fyrkantig",
                    Woodwork = 4000,
                    Stonework = 68000,
                    Smithswork = 280,
                    Iron = 280,
                    Stone = 3400,
                    Wood = 140,
                    Upkeep = 16
                },
                new BuildingType
                {
                    BuildingTypeId = 24,
                    Type = "Borgkärna, rund",
                    Woodwork = 1900,
                    Stonework = 34000,
                    Smithswork = 120,
                    Iron = 120,
                    Stone = 1700,
                    Wood = 58,
                    Upkeep = 8
                },
                new BuildingType
                {
                    BuildingTypeId = 25,
                    Type = "Sammansatt borgkärna",
                    Woodwork = 5700,
                    Stonework = 102000,
                    Smithswork = 340,
                    Iron = 340,
                    Stone = 5100,
                    Wood = 170,
                    Upkeep = 16
                },
                new BuildingType
                {
                    BuildingTypeId = 26,
                    Type = "Trähus",
                    Woodwork = 24,
                    Stonework = 0,
                    Smithswork = 0,
                    Iron = 0,
                    Stone = 0,
                    Wood = 6,
                    Upkeep = 0.025
                },
                new BuildingType
                {
                    BuildingTypeId = 27,
                    Type = "Stenhus",
                    Woodwork = 16,
                    Stonework = 440,
                    Smithswork = 8,
                    Iron = 8,
                    Stone = 22,
                    Wood = 4,
                    Upkeep = 0.025
                },
                new BuildingType
                {
                    BuildingTypeId = 28,
                    Type = "Tvåvånings trähus",
                    Woodwork = 48,
                    Stonework = 0,
                    Smithswork = 8,
                    Iron = 8,
                    Stone = 27,
                    Wood = 12,
                    Upkeep = 0.05
                },
                new BuildingType
                {
                    BuildingTypeId = 29,
                    Type = "Tvåvånings stenhus",
                    Woodwork = 60,
                    Stonework = 880,
                    Smithswork = 8,
                    Iron = 8,
                    Stone = 44,
                    Wood = 4,
                    Upkeep = 0.05
                },
                new BuildingType
                {
                    BuildingTypeId = 30,
                    Type = "Tempel/Kyrka",
                    Woodwork = 1700,
                    Stonework = 47000,
                    Smithswork = 130,
                    Iron = 130,
                    Stone = 1200,
                    Wood = 66,
                    Upkeep = 0
                },
                new BuildingType
                {
                    BuildingTypeId = 31,
                    Type = "Stort tempel/kyrka",
                    Woodwork = 5100,
                    Stonework = 140000,
                    Smithswork = 400,
                    Iron = 400,
                    Stone = 3500,
                    Wood = 200,
                    Upkeep = 0
                },
                new BuildingType
                {
                    BuildingTypeId = 32,
                    Type = "Katedral",
                    Woodwork = 26000,
                    Stonework = 700000,
                    Smithswork = 2000,
                    Iron = 2000,
                    Stone = 18000,
                    Wood = 1000,
                    Upkeep = 0
                }
            );
        }
    }
}