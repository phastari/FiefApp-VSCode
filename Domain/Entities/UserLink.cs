using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class UserLink
    {
        public UserLink()
        {
            GameSessions = new HashSet<GameSession>();
        }

        public Guid UserLinkId { get; set; }
        public string UserName { get; set; }
        public ICollection<GameSession> GameSessions { get; set; }
    }
}