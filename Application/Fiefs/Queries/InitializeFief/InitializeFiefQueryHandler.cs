using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Fiefs.Queries.InitializeFief
{
    public class InitializeFiefQueryHandler : IRequestHandler<InitializeFiefQuery, InitializeFiefVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _currentUser;

        public InitializeFiefQueryHandler(IFiefAppDbContext context, ICurrentUserService currentUser, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser.GetCurrentUsername();
        }

        public async Task<InitializeFiefVm> Handle(InitializeFiefQuery request, CancellationToken cancellationToken)
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

            var industries = await _context.Industries
                .Where(o => o.Fief.GameSessionId.ToString() == request.GameSessionId)
                .ProjectTo<IndustryLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var stewards = await _context.Stewards
                .Where(o => o.GameSessionId.ToString() == request.GameSessionId)
                .ProjectTo<StewardLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var vm = new InitializeFiefVm
            {
                Fiefs = fiefsList,
                Roads = roads,
                Inheritances = inheritances,
                FiefId = fiefsList[0].FiefId,
                Industries = industries,
                Stewards = stewards
            };

            return vm;
        }
    }
}