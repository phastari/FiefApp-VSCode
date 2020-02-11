using System;
using Domain.Entities.Persons;
using Domain.Entities.Types;

namespace Domain.Entities
{
    public class Building
    {
        public Guid BuildingId { get; set; }
#nullable enable
        public virtual Builder? Builder { get; set; }
#nullable disable
        public virtual Fief Fief { get; set; }
        public virtual BuildingType BuildingType { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public int WoodworkThisYear { get; set; }
        public int StoneworkThisYear { get; set; }
        public int SmithsworkThisYear { get; set; }
        public int WoodThisYear { get; set; }
        public int StoneThisYear { get; set; }
        public int IronThisYear { get; set; }
    }
}