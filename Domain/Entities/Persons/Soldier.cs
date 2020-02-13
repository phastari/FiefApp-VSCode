using System;
using Domain.Entities.Industries;
using Domain.Entities.Types;

namespace Domain.Entities.Persons
{
    public class Soldier
    {
        public Guid SoldierId { get; set; }
        public virtual Fief Fief { get; set; }
        public string Name { get; set; } = "";
        public int Skill { get; set; }
        public int Resources { get; set; }
        public int Loyalty { get; set; }
        public int Age { get; set; }
        public virtual SoldierType SoldierType { get; set; }
        public int SoldierTypeId { get; set; }
#nullable enable
        public virtual Merchant? Merchant { get; set; }
        public virtual Boat? Boat { get; set; }
        public virtual Market? Market { get; set; }
        public virtual Port? Port { get; set; }
        public virtual Road? Road { get; set; }
        public virtual Mine? Mine { get; set; }
        public virtual Quarry? Quarry { get; set; }
#nullable disable
        public bool IsResident { get; set; }
        public int Amount { get; set; }
    }
}