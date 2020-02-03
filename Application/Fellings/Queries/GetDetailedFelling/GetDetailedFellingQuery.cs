using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Fellings.Queries.GetDetailedFelling
{
    public class GetDetailedFellingQuery : IRequest<GetDetailedFellingVm>
    {
        public string FellingId { get; set; }
    }

    public class GetDetailedFiefsListQueryHandler : IRequestHandler<GetDetailedFellingQuery, GetDetailedFellingVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _user;

        public GetDetailedFiefsListQueryHandler(IFiefAppDbContext context, ICurrentUserService currentUser, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _user = currentUser.GetCurrentUsername();
        }

        public async Task<GetDetailedFellingVm> Handle(GetDetailedFellingQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.FellingId, out Guid id))
            {
                var felling = await _context.Fellings.FindAsync(id);

                throw new CustomException($"GetDetailedFellingQuery >> Unauthorized!");
            }

            throw new CustomException($"GetDetailedFellingQuery >> Could not parse FellingId({request.FellingId}).");
        }
    }

    public class GetDetailedFellingVm
    {
        public DetailedFellingLookupDto Felling { get; set; }
    }

    public class DetailedFellingLookupDto : IMapFrom<Felling>
    {
        public string IndustryId { get; set; }
        public int AmountLandclearing { get; set; }
        public int AmountLandclearingOfFelling { get; set; }
        public int AmountFelling { get; set; }
        public int AmountClearUseless { get; set; }
        public bool IsBeingDeveloped { get; set; }
        public string DevelopmentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Felling, DetailedFellingLookupDto>()
                .ForMember(d => d.IndustryId, opt => opt.MapFrom(s => s.IndustryId.ToString()))
                .ForMember(d => d.AmountLandclearing, opt => opt.MapFrom(s => s.AmountLandclearing))
                .ForMember(d => d.AmountLandclearingOfFelling, opt => opt.MapFrom(s => s.AmountLandclearingOfFelling))
                .ForMember(d => d.AmountFelling, opt => opt.MapFrom(s => s.AmountFelling))
                .ForMember(d => d.AmountClearUseless, opt => opt.MapFrom(s => s.AmountClearUseless))
                .ForMember(d => d.IsBeingDeveloped, opt => opt.MapFrom(s => s.IsBeingDeveloped))
                .ForMember(d => d.DevelopmentId, opt => opt.MapFrom(s => s.DevelopmentId.ToString()));
        }
    }
}