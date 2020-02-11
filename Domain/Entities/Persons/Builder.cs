using System;

namespace Domain.Entities.Persons
{
    public class Builder
    {
        public Guid BuilderId { get; set; }
        public Guid? AssignmentId { get; set; }
        public virtual Fief Fief { get; set; }
        public string Name { get; set; }
        public int Skill { get; set; }
        public int Resources { get; set; }
        public int Loyalty { get; set; }
        public int Age { get; set; }
    }
}