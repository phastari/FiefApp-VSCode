using Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class RoadTypeConfiguration : IEntityTypeConfiguration<RoadType>
    {
        public void Configure(EntityTypeBuilder<RoadType> builder)
        {
            builder
                .Property(e => e.RoadTypeId)
                .HasColumnName("RoadTypeId")
                .UseIdentityColumn<int>(1, 1);

            builder
                .HasData(new RoadType
                {
                    RoadTypeId = 1,
                    Type = "Stigar",
                    UpgradeBaseCost = 20,
                    UpgradeStoneCost = 0,
                    ModificationFactor = 0.4
                },
                new RoadType
                {
                    RoadTypeId = 2,
                    Type = "Väg",
                    UpgradeBaseCost = 64,
                    UpgradeStoneCost = 15000,
                    ModificationFactor = 1
                },
                new RoadType
                {
                    RoadTypeId = 3,
                    Type = "Stenlagdväg",
                    UpgradeBaseCost = 128,
                    UpgradeStoneCost = 30000,
                    ModificationFactor = 2.8
                },
                new RoadType
                {
                    RoadTypeId = 4,
                    Type = "Kunglig landsväg",
                    UpgradeBaseCost = -1,
                    UpgradeStoneCost = -1,
                    ModificationFactor = 8.4
                });
        }
    }
}