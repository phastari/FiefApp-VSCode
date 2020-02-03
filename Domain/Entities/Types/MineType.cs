using System.Collections.Generic;
using Domain.Entities.Industries;

namespace Domain.Entities.Types
{
    public class MineType
    {
        public MineType()
        {
            Mines = new HashSet<Mine>();
        }

        public int MineTypeId { get; set; }
        public virtual ICollection<Mine> Mines { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public int SilverProduction { get; set; }
        public int IronProduction { get; set; }
        public int LuxuryProduction { get; set; }
        public int Crime { get; set; }
        public int PopulationModifier { get; set; }
    }
}