using Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class LivingconditionTypeConfiguration : IEntityTypeConfiguration<LivingconditionType>
    {
        public void Configure(EntityTypeBuilder<LivingconditionType> builder)
        {
            builder.Property(e => e.LivingconditionTypeId)
                .HasColumnName("LivingconditionTypeId")
                .UseIdentityColumn<int>(1, 1);

            builder.HasData(new LivingconditionType
            {
                LivingconditionTypeId = 1,
                Type = "Nödtorftig",
                BaseCost = 2,
                LuxuryCost = 0,
                FocusGain = -4,
                Description = "Denna levnadsstandard innebär två usla mål mat om dagen, utspätt öl att dricka och ofta små marginaler från svält och sjukdom. Det finns inga tjänare i hushållet. Möblemanget är gammalt och lagat. Så här lever de flesta ofria bondefamiljer, och det är således långt under en länsherres värdighet."
            },
            new LivingconditionType
            {
                LivingconditionTypeId = 2,
                Type = "Gemen",
                BaseCost = 3,
                LuxuryCost = 1,
                FocusGain = 0,
                Description = "Denna levnadsstandard innebär två mål mat om dagen, öl eller billigt vin att dricka och någon enstaka utsvävning med fest eller gamman. Det finns inga tjänare i hushållet, förutom en kokerska. Möblemanget är robust, men inte särskilt vackert. Så här lever de flesta borgarfamiljer, och det är således under en länsherres värdighet."
            },
            new LivingconditionType
            {
                LivingconditionTypeId = 3,
                Type = "God",
                BaseCost = 5,
                LuxuryCost = 2,
                FocusGain = 4,
                Description = "Denna levnadsstandard innebär två rediga mål mat om dagen, varav ett är en mindre bankett med ett flertal rätter. Öl eller vin serveras vid samtliga måltider, och länsherren är god för åtminstone månatliga utsvävningar med fest och gamman. Det finns en handfull tjänare i hushållet och ett flertal kokerskor och kökspigor. Möblemanget är veckert. Så här lever rika borgarfamiljer och måttfulla länsherrar."
            },
            new LivingconditionType
            {
                LivingconditionTypeId = 4,
                Type = "Lyxliv",
                BaseCost = 7,
                LuxuryCost = 4,
                FocusGain = 8,
                Description = "Denna levnadsstandard innebär tre eller fler ypperliga mål mat om dagen, varav två är banketter med ett dussintal rätter. Obegränsade mängder synnerligen fint öl och välsmakande vin serveras vid samtliga måltider, och länsherren är god för utsvävningar med fest och gamman närhelst han så önskar. Det finns massvis av tjänare i hushållet, en eller flera kammarherrar och ett hov av damer och kavaljerer. Möblemanget är exklusivt. Så här lever endast de rikaste i samhället - kungen, de rikaste adelsmännen och ett exklusivt fåtal av handelsfurstar."
            });
        }
    }
}