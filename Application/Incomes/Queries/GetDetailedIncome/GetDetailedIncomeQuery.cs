using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Incomes.Queries.GetDetailedIncome
{
    public class GetDetailedIncomeQuery : IRequest<GetDetailedIncomeVm>
    {
        public string IndustryId { get; set; }
    }

    public class GetDetailedRoadQueryHandler : IRequestHandler<GetDetailedIncomeQuery, GetDetailedIncomeVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _user;

        public GetDetailedRoadQueryHandler(IFiefAppDbContext context, IMapper mapper, ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _user = currentUser.GetCurrentUsername();
        }

        public async Task<GetDetailedIncomeVm> Handle(GetDetailedIncomeQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.IndustryId, out Guid id))
            {
                    var income = await _context.Industries.FindAsync(id);

                    var vm = new GetDetailedIncomeVm
                    {
                        Income = _mapper.Map<DetailedIncomeLookupDto>(income)
                    };

                    return vm;

                throw new CustomException($"GetDetailedIncomeQuery >> Unauthorized!");
            }

            throw new CustomException($"GetDetailedIncomeQuery >> Could not parse IndustryId({request.IndustryId}).");
        }
    }

    public class GetDetailedIncomeVm
    {
        public DetailedIncomeLookupDto Income { get; set; }
    }

    public class DetailedIncomeLookupDto : IMapFrom<Income>
    {
        public Guid IndustryId { get; set; }
        public bool NeedSteward { get; set; }
        public bool ShowInIncomes { get; set; }
        public bool IsBeingDeveloped { get; set; }
        public int Silver { get; set; }
        public int Base { get; set; }
        public int Luxury { get; set; }
        public int Wood { get; set; }
        public double SpringModifier { get; set; }
        public double SummerModifier { get; set; }
        public double FallModifier { get; set; }
        public double WinterModifier { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Income, DetailedIncomeLookupDto>()
                .ForMember(d => d.IndustryId, opt => opt.MapFrom(s => s.IndustryId))
                .ForMember(d => d.NeedSteward, opt => opt.MapFrom(s => s.NeedSteward))
                .ForMember(d => d.ShowInIncomes, opt => opt.MapFrom(s => s.ShowInIncomes))
                .ForMember(d => d.IsBeingDeveloped, opt => opt.MapFrom(s => s.IsBeingDeveloped))
                .ForMember(d => d.Silver, opt => opt.MapFrom(s => s.Silver))
                .ForMember(d => d.Base, opt => opt.MapFrom(s => s.Base))
                .ForMember(d => d.Luxury, opt => opt.MapFrom(s => s.Luxury))
                .ForMember(d => d.Wood, opt => opt.MapFrom(s => s.Wood))
                .ForMember(d => d.SpringModifier, opt => opt.MapFrom(s => s.SpringModifier))
                .ForMember(d => d.SummerModifier, opt => opt.MapFrom(s => s.SummerModifier))
                .ForMember(d => d.FallModifier, opt => opt.MapFrom(s => s.FallModifier))
                .ForMember(d => d.WinterModifier, opt => opt.MapFrom(s => s.WinterModifier));
        }
    }
}