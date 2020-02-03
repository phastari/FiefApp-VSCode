using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Subsidiaries.Queries.GetDetailedSubsidiary
{
    public class GetDetailedSubsidiaryQuery : IRequest<GetDetailedSubsidiaryVm>
    {
        public string IndustryId { get; set; }
    }

    public class GetDetailedSubsidiaryQueryHandler : IRequestHandler<GetDetailedSubsidiaryQuery, GetDetailedSubsidiaryVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _user;

        public GetDetailedSubsidiaryQueryHandler(IFiefAppDbContext context, IMapper mapper, ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _user = currentUser.GetCurrentUsername();
        }

        public async Task<GetDetailedSubsidiaryVm> Handle(GetDetailedSubsidiaryQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.IndustryId, out Guid id))
            {
                var subsidiary = (Subsidiary)await _context.Industries.FindAsync(id);

                if (subsidiary == null)
                {
                    throw new CustomException($"GetDetailedSubsidiaryQuery >> Could not find Subsidiary({request.IndustryId}).");
                }

                var helper = new GetUserNameFromFiefId(_context);
                if (await helper.Check(subsidiary.Fief.FiefId, _user))
                {
                    var vm = new GetDetailedSubsidiaryVm
                    {
                        Subsidiary = _mapper.Map<DetailedSubsidiaryLookupDto>(subsidiary)
                    };

                    return vm;
                }

                throw new CustomException($"GetDetailedIncomeQuery >> Unauthorized!");
            }

            throw new CustomException($"GetDetailedIncomeQuery >> Could not parse IndustryId({request.IndustryId}).");
        }
    }

    public class GetDetailedSubsidiaryVm
    {
        public DetailedSubsidiaryLookupDto Subsidiary { get; set; }
    }

    public class DetailedSubsidiaryLookupDto : IMapFrom<Income>
    {
        public Guid IndustryId { get; set; }
        public int Quality { get; set; }
        public int DevelopmentLevel { get; set; }
        public int Silver { get; set; }
        public int Base { get; set; }
        public int Luxury { get; set; }
        public int DaysworkThisYear { get; set; }
        public bool IsBeingDeveloped { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Subsidiary, DetailedSubsidiaryLookupDto>()
                .ForMember(d => d.IndustryId, opt => opt.MapFrom(s => s.IndustryId))
                .ForMember(d => d.Quality, opt => opt.MapFrom(s => s.Quality))
                .ForMember(d => d.DevelopmentLevel, opt => opt.MapFrom(s => s.DevelopmentLevel))
                .ForMember(d => d.Base, opt => opt.MapFrom(s => s.Base))
                .ForMember(d => d.Luxury, opt => opt.MapFrom(s => s.Luxury))
                .ForMember(d => d.DaysworkThisYear, opt => opt.MapFrom(s => s.DaysworkThisYear))
                .ForMember(d => d.IsBeingDeveloped, opt => opt.MapFrom(s => s.IsBeingDeveloped));
        }
    }
}