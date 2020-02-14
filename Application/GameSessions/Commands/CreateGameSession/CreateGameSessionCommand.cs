using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.GameSessions.Commands.CreateGameSession
{
    public class CreateGameSessionCommand : IRequest<GameSession>
    {

        public class Handler : IRequestHandler<CreateGameSessionCommand, GameSession>
        {
            private readonly IFiefAppDbContext _context;
            private readonly IMediator _mediator;
            private readonly string _user;

            public Handler(IFiefAppDbContext context, IMediator mediator, ICurrentUserService userService)
            {
                _context = context;
                _mediator = mediator;
                _user = userService.GetCurrentUsername();
            }

            public async Task<GameSession> Handle(CreateGameSessionCommand request, CancellationToken cancellationToken)
            {
                var gameSession = new GameSession();

                if (_user == "00000000-0000-0000-0000-000000000000")
                {
                    gameSession.User = "00000000-0000-0000-0000-000000000000";
                }
                else
                {
                    gameSession.User = _user;
                }

                var count = _context.GameSessions.Where(o => o.User == gameSession.User).Count();
                gameSession.Name = $"Session{++count}";
                var fief = gameSession.Fiefs.FirstOrDefault();
                if (fief != null)
                {
                    fief.Name = "Förläning 1";
                }

                _context.GameSessions.Add(gameSession);
                await _context.SaveChangesAsync(cancellationToken);

                return gameSession;
            }
        }
    }
}