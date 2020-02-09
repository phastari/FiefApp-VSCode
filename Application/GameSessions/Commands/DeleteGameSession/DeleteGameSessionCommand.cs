using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.GameSessions.Commands.DeleteGameSession
{
    public class DeleteGameSessionCommand : IRequest<bool>
    {
        public string GameSessionId { get; set; }

        public class Handler : IRequestHandler<DeleteGameSessionCommand, bool>
        {
            private readonly IFiefAppDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IFiefAppDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<bool> Handle(DeleteGameSessionCommand request, CancellationToken cancellationToken)
            {
                var session = await _context.GameSessions.Where(o => o.GameSessionId.ToString() == request.GameSessionId).FirstOrDefaultAsync();

                _context.GameSessions.Remove(session);

                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
        }
    }
}