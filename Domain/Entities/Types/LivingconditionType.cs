using System.Collections.Generic;

namespace Domain.Entities.Types
{
    public class LivingconditionType
    {
        public LivingconditionType()
        {
            Livingconditions = new HashSet<Livingcondition>();
        }

        public int LivingconditionTypeId { get; set; }
        public virtual ICollection<Livingcondition> Livingconditions { get; set; }
        public string Type { get; set; }
        public int BaseCost { get; set; }
        public int LuxuryCost { get; set; }
        public int FocusGain { get; set; }
        public string Description { get; set; }
    }
}