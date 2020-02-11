using System;
using System.Collections.Generic;
using Domain.Entities.Persons;
using Domain.Entities.Types;

namespace Domain.Entities.Industries
{
    public class Quarry : Industry
    {
        public Quarry()
        {
            Soldiers = new HashSet<Soldier>();
            IndustryType = "Quarry";
        }

        public virtual QuarryType QuarryType { get; set; }
        public int QuarryTypeId { get; set; }
        public virtual ICollection<Soldier> Soldiers { get; set; }
        public string Type { get; set; }
        public int Stone { get; set; }
        public bool IsFirstYear { get; set; }
        public int YearsLeft { get; set; }
        public int Guards { get; set; }
        public bool IsBeingDeveloped { get; set; }
        public Guid? DevelopmentId { get; set; }
    }
}