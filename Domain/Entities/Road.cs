using System;
using System.Collections.Generic;
using Domain.Entities.Persons;
using Domain.Entities.Types;

namespace Domain.Entities
{
    public class Road
    {
        public Road()
        {
            Soldiers = new HashSet<Soldier>();
        }

        public Guid RoadId { get; set; }
        public virtual Fief Fief { get; set; }
        public Guid FiefId { get; set; }
        public RoadType RoadType { get; set; }
        public int RoadTypeId { get; set; }
        public ICollection<Soldier> Soldiers { get; set; }
        public string Name { get; set; }
    }
}