using System;
using Domain.Entities.Industries;
using Domain.Entities.Persons;

namespace Domain.Entities
{
    public class Assignment 
    {
        public Guid AssignmentId { get; set; }
        public virtual Steward Steward { get; set; }
        
        // Possible assignments
#nullable enable
        public virtual Industry? Industry { get; set; }
        public virtual Development? Development { get; set; }
        public virtual Fief? Fief { get; set; }
        public virtual Market? Market { get; set; }
        public virtual Port? Port { get; set; }
        public virtual Shipyard? Shipyard { get; set; }
#nullable disable
    }
}