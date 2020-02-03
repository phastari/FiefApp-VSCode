using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.GameSessions.Commands.UpdateGameSession
{
    public class UpdateGameSessionCommand : IRequest<bool>
    {
        public string GameSessionId { get; set; }
        public string Name { get; set; }

        public class Handler : IRequestHandler<UpdateGameSessionCommand, bool>
        {
            private readonly IFiefAppDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IFiefAppDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<bool> Handle(UpdateGameSessionCommand request, CancellationToken cancellationToken)
            {
                var gameSession = await _context.GameSessions.Where(o => o.GameSessionId.ToString() == request.GameSessionId).FirstAsync();

                if (gameSession != null)
                {
                    gameSession.Name = request.Name;
                    await _context.SaveChangesAsync(cancellationToken);

                    return true;
                }

                return false;
            }
        }
    }
}