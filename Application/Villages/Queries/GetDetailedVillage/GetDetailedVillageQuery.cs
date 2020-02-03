using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Villages.Queries.GetDetailedVillage
{
    public class GetDetailedVillageQuery : IRequest<GetDetailedVillageListVm>
    {
        public string VillageId { get; set; }
    }

    public class GetDetailedVillageListQueryHandler : IRequestHandler<GetDetailedVillageQuery, GetDetailedVillageListVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;

        public GetDetailedVillageListQueryHandler(IFiefAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetDetailedVillageListVm> Handle(GetDetailedVillageQuery request, CancellationToken cancellationToken)
        {
            var village = await _context.Villages
                .Where(o => o.VillageId.ToString() == request.VillageId)
                .FirstAsync();

            var vm = new GetDetailedVillageListVm
            {
                Village = _mapper.Map<DetailedVillageLookupDto>(village)
            };

            return vm;
        }
    }

    public class GetDetailedVillageListVm
    {
        public DetailedVillageLookupDto Village { get; set; }
    }

    public class DetailedVillageLookupDto : IMapFrom<Village>
    {
        public string VillageId { get; set; }
        public string Name { get; set; }
        public int Serfdoms { get; set; }
        public int Farmers { get; set; }
        public int Burgess { get; set; }
        public int Boatbuilders { get; set; }
        public int Tanners { get; set; }
        public int Millers { get; set; }
        public int Furriers { get; set; }
        public int Tailors { get; set; }
        public int Blacksmiths { get; set; }
        public int Carpenters { get; set; }
        public int Innkeepers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Village, DetailedVillageLookupDto>()
                .ForMember(d => d.VillageId, opt => opt.MapFrom(s => s.VillageId.ToString()))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Serfdoms, opt => opt.MapFrom(s => s.Serfdoms))
                .ForMember(d => d.Farmers, opt => opt.MapFrom(s => s.Farmers))
                .ForMember(d => d.Burgess, opt => opt.MapFrom(s => s.Burgess))
                .ForMember(d => d.Boatbuilders, opt => opt.MapFrom(s => s.Boatbuilders))
                .ForMember(d => d.Tanners, opt => opt.MapFrom(s => s.Tanners))
                .ForMember(d => d.Millers, opt => opt.MapFrom(s => s.Millers))
                .ForMember(d => d.Furriers, opt => opt.MapFrom(s => s.Furriers))
                .ForMember(d => d.Tailors, opt => opt.MapFrom(s => s.Tailors))
                .ForMember(d => d.Blacksmiths, opt => opt.MapFrom(s => s.Blacksmiths))
                .ForMember(d => d.Carpenters, opt => opt.MapFrom(s => s.Carpenters))
                .ForMember(d => d.Innkeepers, opt => opt.MapFrom(s => s.Innkeepers));
        }
    }
}