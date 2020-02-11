using System;

namespace Domain.Entities.Persons
{
    public class Resident
    {
        public Guid ResidentId { get; set; }
        public virtual Fief Fief { get; set; }
        public string Name { get; set; }
        public int Skill { get; set; }
        public int Resources { get; set; }
        public int Loyalty { get; set; }
        public int Age { get; set; }
        public string Information { get; set; }
    }
}