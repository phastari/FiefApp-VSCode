using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Quarries.Queries.GetDetailedQuarry
{
    public class GetDetailedQuarryQuery : IRequest<GetDetailedQuarryVm>
    {
        public string IndustryId { get; set; }
    }

    public class GetDetailedQuarryQueryHandler : IRequestHandler<GetDetailedQuarryQuery, GetDetailedQuarryVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _user;

        public GetDetailedQuarryQueryHandler(IFiefAppDbContext context, IMapper mapper, ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _user = currentUser.GetCurrentUsername();
        }

        public async Task<GetDetailedQuarryVm> Handle(GetDetailedQuarryQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.IndustryId, out Guid id))
            {
                var mine = (Quarry)await _context.Industries.FindAsync(id);

                if (mine == null)
                {
                    throw new CustomException($"GetDetailedQuarryQuery >> Could not find Quarry({request.IndustryId}).");
                }

                    var vm = new GetDetailedQuarryVm
                    {
                        Quarry = _mapper.Map<DetailedQuarryLookupDto>(mine)
                    };

                    return vm;

                throw new CustomException($"GetDetailedIncomeQuery >> Unauthorized!");
            }

            throw new CustomException($"GetDetailedIncomeQuery >> Could not parse IndustryId({request.IndustryId}).");
        }
    }

    public class GetDetailedQuarryVm
    {
        public DetailedQuarryLookupDto Quarry { get; set; }
    }

    public class DetailedQuarryLookupDto : IMapFrom<Income>
    {
        public Guid IndustryId { get; set; }
        public string Type { get; set; }
        public int Stone { get; set; }
        public int Guards { get; set; }
        public bool IsFirstYear { get; set; }
        public bool IsBeingDeveloped { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Quarry, DetailedQuarryLookupDto>()
                .ForMember(d => d.IndustryId, opt => opt.MapFrom(s => s.IndustryId))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.Stone, opt => opt.MapFrom(s => s.Stone))
                .ForMember(d => d.Guards, opt => opt.MapFrom(s => s.Guards))
                .ForMember(d => d.IsFirstYear, opt => opt.MapFrom(s => s.IsFirstYear))
                .ForMember(d => d.IsBeingDeveloped, opt => opt.MapFrom(s => s.IsBeingDeveloped));
        }
    }
}