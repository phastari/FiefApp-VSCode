using System;
using System.Collections.Generic;
using Domain.Entities.Persons;
using Domain.Entities.Types;

namespace Domain.Entities.Industries
{
    public class Mine : Industry
    {
        public Mine()
        {
            Soldiers = new HashSet<Soldier>();
            IndustryType = "Mine";
        }

        public virtual MineType MineType { get; set; }
        public int MineTypeId { get; set; }
        public virtual ICollection<Soldier> Soldiers { get; set; }
        public string Type { get; set; }
        public int Silver { get; set; }
        public int Luxury { get; set; }
        public int Iron { get; set; }
        public int YearsLeft { get; set; }
        public int Guards { get; set; }
        public bool FirstYear { get; set; }
        public bool IsBeingDeveloped { get; set; }
        public Guid? DevelopmentId { get; set; }
    }
}