using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Roads.Queries.GetRoadsList
{
    public class GetRoadsListQuery : IRequest<GetRoadsListVm>
    {
        public string FiefId { get; set; }
    }

    public class GetRoadsListQueryHandler : IRequestHandler<GetRoadsListQuery, GetRoadsListVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;

        public GetRoadsListQueryHandler(IFiefAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetRoadsListVm> Handle(GetRoadsListQuery request, CancellationToken cancellationToken)
        {
            var types = await _context.RoadTypes
                .ProjectTo<RoadTypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new GetRoadsListVm
            {
                Roads = types
            };

            return vm;
        }
    }

    public class GetRoadsListVm
    {
        public List<RoadTypeLookupDto> Roads { get; set; }
    }

    public class RoadTypeLookupDto : IMapFrom<LivingconditionType>
    {
        public int RoadTypeId { get; set; }
        public string Type { get; set; }
        public int UpgradeBaseCost { get; set; }
        public int UpgradeStoneCost { get; set; }
        public double ModificationFactor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RoadType, RoadTypeLookupDto>()
                .ForMember(d => d.RoadTypeId, opt => opt.MapFrom(s => s.RoadTypeId))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.UpgradeBaseCost, opt => opt.MapFrom(s => s.UpgradeBaseCost))
                .ForMember(d => d.UpgradeStoneCost, opt => opt.MapFrom(s => s.UpgradeStoneCost))
                .ForMember(d => d.ModificationFactor, opt => opt.MapFrom(s => s.ModificationFactor));
        }
    }
}