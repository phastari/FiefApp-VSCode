using System.Collections.Generic;

namespace Domain.Entities.Types
{
    public class InheritanceType
    {
        public int InheritanceTypeId { get; set; }
        public virtual ICollection<Fief> Fiefs { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}