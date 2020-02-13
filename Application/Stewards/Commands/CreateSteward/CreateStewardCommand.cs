using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities.Persons;
using MediatR;

namespace Application.Stewards.Commands.CreateSteward
{
    public class CreateStewardCommand : IRequest<StewardLookupDto>
    {
        public string GameSessionId { get; set; }

        public class Handler : IRequestHandler<CreateStewardCommand, StewardLookupDto>
        {
            private readonly IFiefAppDbContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly string _user;

            public Handler(IFiefAppDbContext context, IMediator mediator, ICurrentUserService userService, IMapper mapper)
            {
                _context = context;
                _mediator = mediator;
                _mapper = mapper;
                _user = userService.GetCurrentUsername();
            }

            public async Task<StewardLookupDto> Handle(CreateStewardCommand request, CancellationToken cancellationToken)
            {
                var session = await _context.GameSessions.FindAsync(request.GameSessionId);

                if (session != null)
                {
                    var steward = new Steward();
                    session.Stewards.Add(steward);
                    await _context.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<StewardLookupDto>(steward);
                }
                
                return null;
            }
        }
    }
}