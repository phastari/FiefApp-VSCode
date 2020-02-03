using System.Collections.Generic;
using Domain.Entities.Industries;

namespace Domain.Entities.Types
{
    public class QuarryType
    {
        public QuarryType()
        {
            Quarries = new HashSet<Quarry>();
        }

        public int QuarryTypeId { get; set; }
        public virtual ICollection<Quarry> Quarries { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public int Crime { get; set; }
        public int PopulationModifier { get; set; }
    }
}