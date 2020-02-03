using Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class SoldierTypeConfiguration : IEntityTypeConfiguration<SoldierType>
    {
        public void Configure(EntityTypeBuilder<SoldierType> builder)
        {
            builder
                .Property(e => e.SoldierTypeId)
                .HasColumnName("SoldierTypeId")
                .UseIdentityColumn<int>(1, 1);

            builder.HasData(
                new SoldierType
                {
                    SoldierTypeId = 1,
                        Type = "Crossbowmen",
                        DisplayName = "Armborstskyttar",
                        SilverCost = 320,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 2,
                        Type = "Bowmen",
                        DisplayName = "Bågskyttar",
                        SilverCost = 160,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 3,
                        Type = "Medics",
                        DisplayName = "Fältskär",
                        SilverCost = 2920,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 4,
                        Type = "MedicsSkilled",
                        DisplayName = "Skicklig fältskär",
                        SilverCost = 4480,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 5,
                        Type = "InfantryLight",
                        DisplayName = "Lätt infanteri",
                        SilverCost = 320,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 6,
                        Type = "Infantry",
                        DisplayName = "Infanteri",
                        SilverCost = 480,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 7,
                        Type = "InfantryHeavy",
                        DisplayName = "Tungt infanteri",
                        SilverCost = 800,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 8,
                        Type = "InfantryElite",
                        DisplayName = "Elit infanteri",
                        SilverCost = 1360,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 9,
                        Type = "Longbowmen",
                        DisplayName = "Långbågsskyttar",
                        SilverCost = 320,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 10,
                        Type = "Mercenary",
                        DisplayName = "Legoknektar",
                        SilverCost = 560,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 11,
                        Type = "MercenaryBowmen",
                        DisplayName = "Bågskyttar, legoknektar",
                        SilverCost = 480,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 12,
                        Type = "MercenaryElite",
                        DisplayName = "Elit legoknektar",
                        SilverCost = 1840,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 13,
                        Type = "Engineers",
                        DisplayName = "Maskinister",
                        SilverCost = 1360,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 14,
                        Type = "Spearmen",
                        DisplayName = "Spjutmän",
                        SilverCost = 320,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 15,
                        Type = "Scouts",
                        DisplayName = "Spejare",
                        SilverCost = 320,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 16,
                        Type = "SkilledScouts",
                        DisplayName = "Skickliga spejare",
                        SilverCost = 480,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 17,
                        Type = "KnightTemplars",
                        DisplayName = "Tempelriddare",
                        SilverCost = 2360,
                        BaseCost = 2,
                        Accommodation = true
                },
                new SoldierType
                {
                    SoldierTypeId = 18,
                        Type = "Guards",
                        DisplayName = "Vakter",
                        SilverCost = 320,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 19,
                        Type = "Weaponmasters",
                        DisplayName = "Vapenmästare",
                        SilverCost = 2400,
                        BaseCost = 2,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 20,
                        Type = "CavalryBowmen",
                        DisplayName = "Kavalleri, bågskyttar",
                        SilverCost = 320,
                        BaseCost = 6,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 21,
                        Type = "CavalryCourier",
                        DisplayName = "Kurirryttare",
                        SilverCost = 320,
                        BaseCost = 4,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 22,
                        Type = "CavalryLight",
                        DisplayName = "Lätt kavalleri",
                        SilverCost = 320,
                        BaseCost = 6,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 23,
                        Type = "CavalryKnights",
                        DisplayName = "Riddare",
                        SilverCost = 3260,
                        BaseCost = 4,
                        Accommodation = true
                },
                new SoldierType
                {
                    SoldierTypeId = 24,
                        Type = "CavalryScouts",
                        DisplayName = "Kavalleri spejare",
                        SilverCost = 480,
                        BaseCost = 6,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 25,
                        Type = "CavalryKnightTemplars",
                        DisplayName = "Kavalleri, tempelriddare",
                        SilverCost = 2360,
                        BaseCost = 4,
                        Accommodation = true
                },
                new SoldierType
                {
                    SoldierTypeId = 26,
                        Type = "CavalryHeavy",
                        DisplayName = "Tungt kavalleri",
                        SilverCost = 1660,
                        BaseCost = 6,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 27,
                        Type = "CavalryElite",
                        DisplayName = "Elit kavalleri",
                        SilverCost = 2040,
                        BaseCost = 6,
                        Accommodation = false
                },
                new SoldierType
                {
                    SoldierTypeId = 28,
                        Type = "OfficerCorporal",
                        DisplayName = "Korporal",
                        SilverCost = 2340,
                        BaseCost = 0,
                        Accommodation = true
                },
                new SoldierType
                {
                    SoldierTypeId = 29,
                        Type = "OfficerSergeant",
                        DisplayName = "Sergeant",
                        SilverCost = 3120,
                        BaseCost = 0,
                        Accommodation = true
                },
                new SoldierType
                {
                    SoldierTypeId = 30,
                        Type = "OfficerCaptain",
                        DisplayName = "Kapten",
                        SilverCost = 4680,
                        BaseCost = 0,
                        Accommodation = true
                }
            );
        }
    }
}