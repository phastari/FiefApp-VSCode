using System;
using System.Threading.Tasks;

namespace Application.Common.Helpers
{
    public class GetUserNameFromFiefId
    {
        private readonly IFiefAppDbContext _context;

        public GetUserNameFromFiefId(IFiefAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Check(Guid fiefId, string userName)
        {
            var fief = await _context.Fiefs.FindAsync(fiefId);
            if (fief == null)
            {
                return false;
            }

            var session = await _context.GameSessions.FindAsync(fief.GameSessionId);
            if (session == null)
            {
                return false;
            }

            var link = await _context.UserLinks.FindAsync(session.UserLinkId);
            if (link == null)
            {
                return false;
            }

            if (userName == link.UserName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}