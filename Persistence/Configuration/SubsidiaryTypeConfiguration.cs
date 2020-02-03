using Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class SubsidiaryTypeConfiguration : IEntityTypeConfiguration<SubsidiaryType>
    {
        public void Configure(EntityTypeBuilder<SubsidiaryType> builder)
        {
            builder
                .Property(e => e.SubsidiaryTypeId)
                .HasColumnName("SubsidiaryTypeId")
                .UseIdentityColumn<int>(1, 1);

            builder
                .HasData(
                    new SubsidiaryType
                    {
                        SubsidiaryTypeId = 1,
                            Type = "Beekeeping",
                            DisplayName = "Biodling",
                            IncomeFactor = 15,
                            IncomeInBase = 0.35,
                            IncomeInLuxury = 0.25,
                            IncomeInSilver = 0.4,
                            DaysworkUpkeep = 365,
                            DaysworkBuild = 730,
                            SpringModification = 0.35,
                            SummerModification = 0.5,
                            FallModification = 0.1,
                            WinterModification = 0.05
                    },
                    new SubsidiaryType
                    {
                        SubsidiaryTypeId = 2,
                            Type = "Fishfarms",
                            DisplayName = "Fiskdammar",
                            IncomeFactor = 0.2,
                            IncomeInBase = 1,
                            IncomeInLuxury = 0,
                            IncomeInSilver = 0,
                            DaysworkUpkeep = 365,
                            DaysworkBuild = 1095,
                            SpringModification = 0.35,
                            SummerModification = 0.35,
                            FallModification = 0.25,
                            WinterModification = 0.05
                    },
                    new SubsidiaryType
                    {
                        SubsidiaryTypeId = 3,
                            Type = "Glassworks",
                            DisplayName = "Glasbruk",
                            IncomeFactor = 0.2,
                            IncomeInBase = 0,
                            IncomeInLuxury = 1,
                            IncomeInSilver = 0,
                            DaysworkUpkeep = 365,
                            DaysworkBuild = 4225,
                            SpringModification = 0,
                            SummerModification = 0,
                            FallModification = 0,
                            WinterModification = 0
                    },
                    new SubsidiaryType
                    {
                        SubsidiaryTypeId = 4,
                            Type = "Olivegrove",
                            DisplayName = "Olivlundar",
                            IncomeFactor = 20,
                            IncomeInBase = 0.6,
                            IncomeInLuxury = 0.2,
                            IncomeInSilver = 0.2,
                            DaysworkUpkeep = 1460,
                            DaysworkBuild = 5320,
                            SpringModification = 0.25,
                            SummerModification = 0.35,
                            FallModification = 0.25,
                            WinterModification = 0.15
                    },
                    new SubsidiaryType
                    {
                        SubsidiaryTypeId = 5,
                            Type = "Wineregion",
                            DisplayName = "Vindistrikt",
                            IncomeFactor = 20,
                            IncomeInBase = 0.25,
                            IncomeInLuxury = 0.4,
                            IncomeInSilver = 0.35,
                            DaysworkUpkeep = 2920,
                            DaysworkBuild = 5320,
                            SpringModification = 0.25,
                            SummerModification = 0.3,
                            FallModification = 0.25,
                            WinterModification = 0.2
                    },
                    new SubsidiaryType
                    {
                        SubsidiaryTypeId = 6,
                            Type = "Applegrove",
                            DisplayName = "Äppellundar",
                            IncomeFactor = 20,
                            IncomeInBase = 1,
                            IncomeInLuxury = 0,
                            IncomeInSilver = 0,
                            DaysworkUpkeep = 730,
                            DaysworkBuild = 3285,
                            SpringModification = 0.3,
                            SummerModification = 0.3,
                            FallModification = 0.3,
                            WinterModification = 0.1
                    }
                );
        }
    }
}