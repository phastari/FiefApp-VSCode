using System;

namespace Domain.Entities.Persons
{
    public class Steward
    {
        public Steward()
        {
            Assignment = new Assignment();
        }
        
        public Guid StewardId { get; set; }
        public virtual GameSession GameSession { get; set; }
        public Guid GameSessionId { get; set; }
        public string Name { get; set; } = "";
        public int Skill { get; set; }
        public int Resources { get; set; }
        public int Loyalty { get; set; }
        public int Age { get; set; }
        public virtual Assignment Assignment { get; set; }
        public Guid AssignmentId {get; set;}
    }
}