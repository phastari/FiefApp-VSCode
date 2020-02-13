using System;
using System.Collections.Generic;

namespace Domain.Entities.Persons
{
    public class Merchant
    {
        public Merchant()
        {
            Soldiers = new HashSet<Soldier>();
        }

        public Guid MerchantId { get; set; }
#nullable enable
        public virtual Cargo? Cargo { get; set; }
#nullable disable
        public virtual Port Port { get; set; }
        public virtual ICollection<Soldier> Soldiers { get; set; }
        public string Status { get; set; }
        public string Name { get; set; } = "";
        public int Skill { get; set; }
        public int Resources { get; set; }
        public int Loyalty { get; set; }
        public int Age { get; set; }
    }
}