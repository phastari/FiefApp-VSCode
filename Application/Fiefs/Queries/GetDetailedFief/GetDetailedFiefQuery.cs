using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.Fiefs.Queries.GetDetailedFief
{
    public class GetDetailedFiefQuery : IRequest<GetDetailedFiefsListVm>
    {
        public string Id { get; set; }
    }

    public class GetDetailedFiefQueryHandler : IRequestHandler<GetDetailedFiefQuery, GetDetailedFiefsListVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _currentUser;

        public GetDetailedFiefQueryHandler(IFiefAppDbContext context, ICurrentUserService currentUser, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser.GetCurrentUsername();
        }

        public async Task<GetDetailedFiefsListVm> Handle(GetDetailedFiefQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.Id, out Guid id))
            {
                var fief = await _context.Fiefs.FindAsync(id);

                if (fief == null)
                {
                    var session = await _context.GameSessions.FindAsync(id);

                    if (session == null)
                    {
                        throw new CustomException($"GetDetailedFiefQuery >> Could't find fief or gamesession with (id:{id}).");
                    }

                    fief = _context.Fiefs.Where(o => o.GameSessionId == session.GameSessionId).First();

                    if (fief == null)
                    {
                        throw new CustomException($"GetDetailedFiefQuery >> Could not find fief({id}).");
                    }
                }

                var vm = new GetDetailedFiefsListVm
                {
                    Fief = _mapper.Map<DetailedFiefLookupDto>(fief)
                };

                //vm.Fief.Market = _mapper.Map<MarketLookupDto>(fief.Market);
                

                return vm;
            }

            throw new CustomException($"GetDetailedFiefQuery >> Could not parse ({request.Id}).");
        }
    }

    public class GetDetailedFiefsListVm
    {
        public DetailedFiefLookupDto Fief { get; set; }
    }
}