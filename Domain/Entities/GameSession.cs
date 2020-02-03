using System;
using System.Collections.Generic;
using Domain.Entities.Persons;

namespace Domain.Entities
{
    public class GameSession
    {
        public GameSession()
        {
            Fiefs = new HashSet<Fief>();
            Stewards = new HashSet<Steward>();
        }
        public Guid GameSessionId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Fief> Fiefs { get; set; }
        public virtual ICollection<Steward> Stewards { get; set; }
        public UserLink UserLink { get; set; }
        public Guid UserLinkId { get; set; }
    }
}