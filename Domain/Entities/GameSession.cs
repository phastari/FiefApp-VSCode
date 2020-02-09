using System;
using System.Collections.Generic;
using Domain.Entities.Persons;

namespace Domain.Entities
{
    public class GameSession
    {
        public GameSession()
        {
            Fiefs = new HashSet<Fief> {
                new Fief()
            };
            Stewards = new HashSet<Steward>();
            Created = DateTime.UtcNow;
        }
        public Guid GameSessionId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Fief> Fiefs { get; set; }
        public virtual ICollection<Steward> Stewards { get; set; }
        public string User { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUsed { get; set; }
    }
}