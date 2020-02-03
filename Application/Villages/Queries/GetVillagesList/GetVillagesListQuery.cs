using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Villages.Queries.GetVillagesList
{
    public class GetVillagesListQuery : IRequest<GetVillagesListVm>
    {
        public string FiefId { get; set; }
    }

    public class GetVillagesListQueryHandler : IRequestHandler<GetVillagesListQuery, GetVillagesListVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;

        public GetVillagesListQueryHandler(IFiefAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetVillagesListVm> Handle(GetVillagesListQuery request, CancellationToken cancellationToken)
        {
            var villages = await _context.Villages
                .Where(o => o.Fief.FiefId.ToString() == request.FiefId)
                .ProjectTo<VillageLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new GetVillagesListVm
            {
                Villages = villages
            };

            return vm;
        }
    }

    public class GetVillagesListVm
    {
        public List<VillageLookupDto> Villages { get; set; }
    }

    public class VillageLookupDto : IMapFrom<Village>
    {
        public int VillageId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Village, VillageLookupDto>()
                .ForMember(d => d.VillageId, opt => opt.MapFrom(s => s.VillageId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Population, opt => opt.MapFrom(s => s.Serfdoms + s.Farmers + s.Burgess));
        }
    }
}