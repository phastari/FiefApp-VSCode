using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Roads.Queries.GetDetailedRoad
{
    public class GetDetailedRoadQuery : IRequest<GetDetailedRoadVm>
    {
        public string FiefId { get; set; }
    }

    public class GetDetailedRoadQueryHandler : IRequestHandler<GetDetailedRoadQuery, GetDetailedRoadVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;

        public GetDetailedRoadQueryHandler(IFiefAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetDetailedRoadVm> Handle(GetDetailedRoadQuery request, CancellationToken cancellationToken)
        {
            var fief = await _context.Fiefs
                .Where(o => o.FiefId.ToString() == request.FiefId)
                .FirstAsync();

            var vm = new GetDetailedRoadVm
            {
                Road = _mapper.Map<DetailedRoadLookupDto>(fief.Road)
            };

            return vm;
        }
    }

    public class GetDetailedRoadVm
    {
        public DetailedRoadLookupDto Road { get; set; }
    }

    public class DetailedRoadLookupDto : IMapFrom<Road>
    {
        public int RoadTypeId { get; set; }
        public string Type { get; set; }
        public int UpgradeBaseCost { get; set; }
        public int UpgradeStoneCost { get; set; }
        public double ModificationFactor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Road, DetailedRoadLookupDto>()
                .ForMember(d => d.RoadTypeId, opt => opt.MapFrom(s => s.RoadTypeId))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.RoadType.Type))
                .ForMember(d => d.UpgradeBaseCost, opt => opt.MapFrom(s => s.RoadType.UpgradeBaseCost))
                .ForMember(d => d.UpgradeStoneCost, opt => opt.MapFrom(s => s.RoadType.UpgradeStoneCost))
                .ForMember(d => d.ModificationFactor, opt => opt.MapFrom(s => s.RoadType.ModificationFactor));
        }
    }
}