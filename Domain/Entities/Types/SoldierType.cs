using System.Collections.Generic;
using Domain.Entities.Persons;

namespace Domain.Entities.Types
{
    public class SoldierType
    {
        public SoldierType()
        {
            Soldiers = new HashSet<Soldier>();
        }

        public int SoldierTypeId { get; set; }
        public ICollection<Soldier> Soldiers { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public int SilverCost { get; set; }
        public int BaseCost { get; set; }
        public bool Accommodation { get; set; }
    }
}