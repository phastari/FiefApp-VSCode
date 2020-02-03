using System;

namespace Domain.Entities.Persons
{
    public class Boatbuilder
    {
        public Guid BoatbuilderId { get; set; }
        public Guid? AssignmentId { get; set; }
        public Shipyard Shipyard { get; set; }
        public string Name { get; set; }
        public int Skill { get; set; }
        public int Resources { get; set; }
        public int Loyalty { get; set; }
        public int Age { get; set; }
    }
}