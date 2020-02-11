using System;
using System.Collections.Generic;
using Domain.Entities.Persons;

namespace Domain.Entities
{
    public class Port
    {
        public Port()
        {
            Boats = new HashSet<Boat>();
            Merchants = new HashSet<Merchant>();
            Soldiers = new HashSet<Soldier>();
        }

        public Guid PortId { get; set; }
        public virtual Fief Fief { get; set; }
        public Guid FiefId { get; set; }
#nullable enable
        public virtual Assignment? Assignment { get; set; }
        public Guid? AssignmentId { get; set; }
        public virtual Shipyard? Shipyard { get; set; }
#nullable disable
        public virtual ICollection<Boat> Boats { get; set; }
        public virtual ICollection<Merchant> Merchants { get; set; }
        public virtual ICollection<Soldier> Soldiers { get; set; }
        public string Name { get; set; }
        public int DevelopmentLevel { get; set; }
        public int Merchandise { get; set; }
        public int IncomeSilver { get; set; }
        public int Taxes { get; set; }
        public int Bailiffs { get; set; }
        public int Crime { get; set; }
        public bool IsBeingDeveloped { get; set; }
    }
}