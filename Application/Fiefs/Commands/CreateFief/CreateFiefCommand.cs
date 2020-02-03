using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Fiefs.Commands.CreateFief
{
    public class CreateFiefCommand : IRequest<bool>
    {
        public string GameSessionId { get; set; }

        public class Handler : IRequestHandler<CreateFiefCommand, bool>
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

            public async Task<bool> Handle(CreateFiefCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.GameSessionId, out Guid id))
                {
                    var session = await _context.GameSessions.FindAsync(id);

                    if (session != null)
                    {
                        var userLinkId = session.UserLinkId;
                        var link = _context.UserLinks.Where(o => o.UserLinkId == userLinkId).First();

                        if (link.UserName == _user)
                        {
                            var fief = new Fief { GameSessionId = id };
                            session.Fiefs.Add(fief);
                            await _context.SaveChangesAsync(cancellationToken);

                            return true;
                        }

                        throw new CustomException($"CreateFiefCommand >> GameSession does not belong to user: '{_user}'.");
                    }

                    throw new CustomException($"CreateFiefCommand >> GameSession with id: '{id}' could not be found.");
                }

                throw new CustomException($"CreateFiefCommand >> GameSessionId('{ request.GameSessionId }') could not be parsed to a Guid.");
            }
        }
    }
}