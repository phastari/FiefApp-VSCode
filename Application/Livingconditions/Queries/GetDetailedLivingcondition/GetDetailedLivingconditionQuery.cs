using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Livingconditions.Queries.GetDetailedLivingcondition
{
    public class GetDetailedLivingconditionQuery : IRequest<GetDetailedLivingconditionVm>
    {
        public string FiefId { get; set; }
    }

    public class GetDetailedLivingconditionQueryHandler : IRequestHandler<GetDetailedLivingconditionQuery, GetDetailedLivingconditionVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;

        public GetDetailedLivingconditionQueryHandler(IFiefAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetDetailedLivingconditionVm> Handle(GetDetailedLivingconditionQuery request, CancellationToken cancellationToken)
        {
            var fief = await _context.Fiefs
                .Where(o => o.FiefId.ToString() == request.FiefId)
                .FirstAsync();

            var vm = new GetDetailedLivingconditionVm
            {
                Livingconditions = _mapper.Map<DetailedLivingconditionLookupDto>(fief.Livingcondition)
            };

            return vm;
        }
    }

    public class GetDetailedLivingconditionVm
    {
        public DetailedLivingconditionLookupDto Livingconditions { get; set; }
    }

    public class DetailedLivingconditionLookupDto : IMapFrom<Livingcondition>
    {
        public string LivingconditionId { get; set; }
        public int LivingconditionTypeId { get; set; }
        public string Type { get; set; }
        public int BaseCost { get; set; }
        public int LuxuryCost { get; set; }
        public int FocusGain { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Livingcondition, DetailedLivingconditionLookupDto>()
                .ForMember(d => d.LivingconditionTypeId, opt => opt.MapFrom(s => s.LivingconditionTypeId))
                .ForMember(d => d.LivingconditionId, opt => opt.MapFrom(s => s.LivingconditionId))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.LivingconditionType.Type))
                .ForMember(d => d.FocusGain, opt => opt.MapFrom(s => s.LivingconditionType.FocusGain))
                .ForMember(d => d.LuxuryCost, opt => opt.MapFrom(s => s.LivingconditionType.LuxuryCost))
                .ForMember(d => d.BaseCost, opt => opt.MapFrom(s => s.LivingconditionType.BaseCost))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.LivingconditionType.BaseCost));
        }
    }
}