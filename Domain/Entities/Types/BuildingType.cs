using System;
using System.Collections.Generic;

namespace Domain.Entities.Types
{
    public class BuildingType
    {
        public BuildingType()
        {
            Buildings = new HashSet<Building>();
        }

        public int BuildingTypeId { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public string Type { get; set; }
        public double Upkeep { get; set; }
        public int Woodwork { get; set; }
        public int Stonework { get; set; }
        public int Smithswork { get; set; }
        public int Wood { get; set; }
        public int Stone { get; set; }
        public int Iron { get; set; }
    }
}