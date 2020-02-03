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

namespace Application.Mines.Queries.GetDetailedMine
{
    public class GetDetailedMineQuery : IRequest<GetDetailedMineVm>
    {
        public string IndustryId { get; set; }
    }

    public class GetDetailedMineQueryHandler : IRequestHandler<GetDetailedMineQuery, GetDetailedMineVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _user;

        public GetDetailedMineQueryHandler(IFiefAppDbContext context, IMapper mapper, ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _user = currentUser.GetCurrentUsername();
        }

        public async Task<GetDetailedMineVm> Handle(GetDetailedMineQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.IndustryId, out Guid id))
            {
                var mine = (Mine)await _context.Industries.FindAsync(id);

                if (mine == null)
                {
                    throw new CustomException($"GetDetailedMineQuery >> Could not find Mine({request.IndustryId}).");
                }

                var helper = new GetUserNameFromFiefId(_context);
                if (await helper.Check(mine.Fief.FiefId, _user))
                {
                    var vm = new GetDetailedMineVm
                    {
                        Mine = _mapper.Map<DetailedMineLookupDto>(mine)
                    };

                    return vm;
                }

                throw new CustomException($"GetDetailedIncomeQuery >> Unauthorized!");
            }

            throw new CustomException($"GetDetailedIncomeQuery >> Could not parse IndustryId({request.IndustryId}).");
        }
    }

    public class GetDetailedMineVm
    {
        public DetailedMineLookupDto Mine { get; set; }
    }

    public class DetailedMineLookupDto : IMapFrom<Income>
    {
        public Guid IndustryId { get; set; }
        public string Type { get; set; }
        public int Silver { get; set; }
        public int Luxury { get; set; }
        public int Iron { get; set; }
        public int Guards { get; set; }
        public bool FirstYear { get; set; }
        public bool IsBeingDeveloped { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Mine, DetailedMineLookupDto>()
                .ForMember(d => d.IndustryId, opt => opt.MapFrom(s => s.IndustryId))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.Silver, opt => opt.MapFrom(s => s.Silver))
                .ForMember(d => d.Luxury, opt => opt.MapFrom(s => s.Luxury))
                .ForMember(d => d.Iron, opt => opt.MapFrom(s => s.Iron))
                .ForMember(d => d.Guards, opt => opt.MapFrom(s => s.Guards))
                .ForMember(d => d.FirstYear, opt => opt.MapFrom(s => s.FirstYear))
                .ForMember(d => d.IsBeingDeveloped, opt => opt.MapFrom(s => s.IsBeingDeveloped));
        }
    }
}