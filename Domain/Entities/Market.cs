using System;
using System.Collections.Generic;
using Domain.Entities.Persons;

namespace Domain.Entities
{
    public class Market
    {
        public Market()
        {
            Merchants = new HashSet<Merchant>();
            Soldiers = new HashSet<Soldier>();
        }

        public Guid MarketId { get; set; }
        #nullable enable
        public Assignment? Assignment { get; set; }
        public Guid? AssignmentId { get; set; }
        #nullable disable
        public ICollection<Merchant> Merchants { get; set; }
        public virtual Fief Fief { get; set; }
        public Guid FiefId {get; set;}
        public ICollection<Soldier> Soldiers { get; set; }
        public string Name { get; set; }
        public int DevelopmentLevel { get; set; }
        public int Merchandise { get; set; }
        public int IncomeSilver { get; set; }
        public int IncomeBase { get; set; }
        public int Taxes { get; set; }
        public int Bailiffs { get; set; }
        public int Crime { get; set; }
        public bool IsBeingDeveloped { get; set; }
    }
}