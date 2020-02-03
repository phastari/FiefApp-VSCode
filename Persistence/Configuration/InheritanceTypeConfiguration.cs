using Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class InheritanceTypeConfiguration : IEntityTypeConfiguration<InheritanceType>
    {
        public void Configure(EntityTypeBuilder<InheritanceType> builder)
        {
            builder
                .Property(e => e.InheritanceTypeId)
                .HasColumnName("InheritanceTypeId")
                .UseIdentityColumn<int>(1, 1);

            builder
                .HasData(new InheritanceType
                {
                    InheritanceTypeId = 1,
                    Type = "Län på tjänst, ärftligt",
                    Description = "Kallas även län på ed. Vasallen får sin förläning mot att han utför eller utfört länsherren en tjänst, exempelvis vapentjänst. Länet är ärftligt, det vill säga går vidare till vasallens son vid vasallens frånfall."
                },
                new InheritanceType
                {
                    InheritanceTypeId = 2,
                    Type = "Län på tjänst, icke ärftligt",
                    Description = "Kallas även län på ed. Vasallen får sin förläning mot att han utför eller utfört länsherren en tjänst, exempelvis vapentjänst. Länet är inte ärftligt utan går tillbaka till länsherren då vasallen dör."
                },
                new InheritanceType
                {
                    InheritanceTypeId = 3,
                    Type = "Län på avgift",
                    Description = "Vasallen betalar en fast avgift till sin länsherre mot att han fritt får disponera länets inkomster."
                },
                new InheritanceType
                {
                    InheritanceTypeId = 4,
                    Type = "Pantlän",
                    Description = "Ibland händer det att en länsherre måste låna pengar, till exempel i tider av ofred. Länsherren kan då skänka långivaren ett län att disponera fritt tills dess att lånet är återbetlat."
                }
            );
        }
    }
}