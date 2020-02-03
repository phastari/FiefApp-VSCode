using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Livingconditions.Queries.GetLivingconditionsListQuery
{
    public class GetLivingconditionsListQuery : IRequest<GetLivingconditionsListVm>
    {
        public string FiefId { get; set; }
    }

    public class GetLivingconditionsListQueryHandler : IRequestHandler<GetLivingconditionsListQuery, GetLivingconditionsListVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;

        public GetLivingconditionsListQueryHandler(IFiefAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetLivingconditionsListVm> Handle(GetLivingconditionsListQuery request, CancellationToken cancellationToken)
        {
            var types = await _context.LivingconditionTypes
                .ProjectTo<LivingconditionTypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new GetLivingconditionsListVm
            {
                Livingconditions = types
            };

            return vm;
        }
    }

    public class GetLivingconditionsListVm
    {
        public List<LivingconditionTypeLookupDto> Livingconditions { get; set; }
    }

    public class LivingconditionTypeLookupDto : IMapFrom<LivingconditionType>
    {
        public int LivingconditionTypeId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LivingconditionType, LivingconditionTypeLookupDto>()
                .ForMember(d => d.LivingconditionTypeId, opt => opt.MapFrom(s => s.LivingconditionTypeId))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description));
        }
    }
}