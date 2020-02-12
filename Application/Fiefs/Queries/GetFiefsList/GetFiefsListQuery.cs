using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Fiefs.Queries.GetFiefsList
{
    public class GetFiefsListQuery : IRequest<GetFiefsListVm>
    {
        public string GameSessionId { get; set; }
    }

    public class GetFiefsListQueryHandler : IRequestHandler<GetFiefsListQuery, GetFiefsListVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _currentUser;

        public GetFiefsListQueryHandler(IFiefAppDbContext context, ICurrentUserService currentUser, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser.GetCurrentUsername();
        }

        public async Task<GetFiefsListVm> Handle(GetFiefsListQuery request, CancellationToken cancellationToken)
        {
            var fiefs = await _context.Fiefs
                .Where(o => o.GameSessionId.ToString() == request.GameSessionId)
                .ToListAsync(cancellationToken);

            var fiefsList = new List<ShortFief>();
            foreach (var fief in fiefs)
            {
                fiefsList.Add(new ShortFief 
                {
                    FiefId = fief.FiefId.ToString(),
                    Name = fief.Name
                });
            };

            var roads = new List<ShortRoad>();
            foreach (var road in _context.RoadTypes)
            {
                roads.Add(new ShortRoad
                {
                    RoadTypeId = road.RoadTypeId,
                    Type = road.Type
                });
            };

            var inheritances = new List<ShortInheritance>();
            foreach (var inheritance in _context.InheritanceTypes)
            {
                inheritances.Add(new ShortInheritance
                {
                    InheritanceTypeId = inheritance.InheritanceTypeId,
                    Type = inheritance.Type,
                    Description = inheritance.Description
                });
            };

            var vm = new GetFiefsListVm
            {
                Fiefs = fiefsList,
                Roads = roads,
                Inheritances = inheritances,
                FiefId = fiefsList[0].FiefId
            };

            return vm;
        }
    }

    public class GetFiefsListVm
    {
        public List<ShortFief> Fiefs { get; set; }
        public List<ShortRoad> Roads { get; set; }
        public List<ShortInheritance> Inheritances { get; set; }
        public string FiefId { get; set; }
    }
}