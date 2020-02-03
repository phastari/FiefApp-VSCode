using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.GameSessions.Commands.CreateGameSession
{
    public class CreateGameSessionCommand : IRequest<string>
    {

        public class Handler : IRequestHandler<CreateGameSessionCommand, string>
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

            public async Task<string> Handle(CreateGameSessionCommand request, CancellationToken cancellationToken)
            {
                var userLink = new UserLink();

                if (_user == "00000000-0000-0000-0000-000000000000")
                {
                    userLink.UserName = "00000000-0000-0000-0000-000000000000";
                }
                else
                {
                    userLink.UserName = _user;
                }

                _context.UserLinks.Add(userLink);
                await _context.SaveChangesAsync(cancellationToken);
                var gameSession = new GameSession
                {
                    UserLinkId = userLink.UserLinkId
                };

                _context.GameSessions.Add(gameSession);
                await _context.SaveChangesAsync(cancellationToken);

                var fief = new Fief { GameSessionId = gameSession.GameSessionId };
                gameSession.Fiefs.Add(fief);
                await _context.SaveChangesAsync(cancellationToken);

                return gameSession.GameSessionId.ToString();
            }
        }
    }
}