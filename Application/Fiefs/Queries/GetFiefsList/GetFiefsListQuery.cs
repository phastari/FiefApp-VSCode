using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
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
                .ProjectTo<FiefLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new GetFiefsListVm
            {
                Fiefs = fiefs
            };

            return vm;
        }
    }

    public class GetFiefsListVm
    {
        public List<FiefLookupDto> Fiefs { get; set; }
    }

    public class FiefLookupDto : IMapFrom<Fief>
    {
        public string FiefId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Fief, FiefLookupDto>()
                .ForMember(d => d.FiefId, opt => opt.MapFrom(s => s.FiefId.ToString()))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}