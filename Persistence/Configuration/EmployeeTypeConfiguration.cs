using Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class EmployeeTypeConfiguration : IEntityTypeConfiguration<EmployeeType>
    {
        public void Configure(EntityTypeBuilder<EmployeeType> builder)
        {
            builder
                .Property(e => e.EmployeeTypeId)
                .HasColumnName("EmployeeTypeId")
                .UseIdentityColumn<int>(1, 1);

            builder
                .HasData(new EmployeeType
                {
                    EmployeeTypeId = 1,
                    Type = "Falconer",
                    BaseCost = 2,
                    LuxuryCost = 1
                },
                new EmployeeType
                {
                    EmployeeTypeId = 2,
                    Type = "Bailiff",
                    BaseCost = 3,
                    LuxuryCost = 1
                },
                new EmployeeType
                {
                    EmployeeTypeId = 3,
                    Type = "Herald",
                    BaseCost = 4,
                    LuxuryCost = 1
                },
                new EmployeeType
                {
                    EmployeeTypeId = 4,
                    Type = "Hunter",
                    BaseCost = 2,
                    LuxuryCost = 0
                },
                new EmployeeType
                {
                    EmployeeTypeId = 5,
                    Type = "Physician",
                    BaseCost = 3,
                    LuxuryCost = 3
                },
                new EmployeeType
                {
                    EmployeeTypeId = 6,
                    Type = "Scholar",
                    BaseCost = 3,
                    LuxuryCost = 1
                },
                new EmployeeType
                {
                    EmployeeTypeId = 7,
                    Type = "Cupbearer",
                    BaseCost = 2,
                    LuxuryCost = 1
                },
                new EmployeeType
                {
                    EmployeeTypeId = 8,
                    Type = "Prospector",
                    BaseCost = 2,
                    LuxuryCost = -1
                });
        }
    }
}