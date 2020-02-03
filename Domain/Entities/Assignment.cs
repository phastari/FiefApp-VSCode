using System;
using Domain.Entities.Industries;
using Domain.Entities.Persons;

namespace Domain.Entities
{
    public class Assignment 
    {
        public Guid AssignmentId { get; set; }
        public Steward Steward { get; set; }
        
        // Possible assignments
#nullable enable
        public Industry? Industry { get; set; }
        public Development? Development { get; set; }
        public Fief? Fief { get; set; }
        public Market? Market { get; set; }
        public Port? Port { get; set; }
        public Shipyard? Shipyard { get; set; }
#nullable disable
    }
}