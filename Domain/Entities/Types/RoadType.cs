using System;
using System.Collections.Generic;

namespace Domain.Entities.Types
{
    public class RoadType
    {
        public RoadType()
        {
            Roads = new HashSet<Road>();
        }

        public int RoadTypeId { get; set; }
        public virtual ICollection<Road> Roads { get; set; }
        public string Type { get; set; }
        public int UpgradeBaseCost { get; set; }
        public int UpgradeStoneCost { get; set; }
        public double ModificationFactor { get; set; }
    }
}