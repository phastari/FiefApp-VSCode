using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Fiefs.Commands.CreateFief
{
    public class CreateFiefCommand : IRequest<FiefLookupDto>
    {
        public string GameSessionId { get; set; }

        public class Handler : IRequestHandler<CreateFiefCommand, FiefLookupDto>
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

            public async Task<FiefLookupDto> Handle(CreateFiefCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.GameSessionId, out Guid id))
                {
                    var session = await _context.GameSessions.FindAsync(id);

                    if (session != null)
                    {
                        if (session.User == _user)
                        {
                            var count = session.Fiefs.Count;
                            var fief = new Fief { Name = $"Förläning {count++}" };
                            session.Fiefs.Add(fief);
                            await _context.SaveChangesAsync(cancellationToken);

                            fief.Livingcondition.LivingconditionType = await _context.LivingconditionTypes.Where(o => o.LivingconditionTypeId == 3).FirstAsync();
                            fief.Road.RoadType = await _context.RoadTypes.Where(o => o.RoadTypeId == 2).FirstAsync();
                            fief.Inheritance.InheritanceType = await _context.InheritanceTypes.Where(o => o.InheritanceTypeId == 1).FirstAsync();

                            return _mapper.Map<FiefLookupDto>(fief);
                        }

                        // GameSession does not belong to the user.
                        return null;
                    }

                    // GameSession with id could not be found.
                    return null;
                }

                // GameSessionId could not be parsed to a Guid.
                return null;
            }
        }
    }
}