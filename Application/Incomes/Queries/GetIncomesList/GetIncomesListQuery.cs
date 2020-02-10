using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Industries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Incomes.Queries.GetIncomesList
{
    public class GetIncomesListQuery : IRequest<GetIncomesListVm>
    {
        public string FiefId { get; set; }
    }

    public class GetDetailedRoadQueryHandler : IRequestHandler<GetIncomesListQuery, GetIncomesListVm>
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

        public async Task<GetIncomesListVm> Handle(GetIncomesListQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.FiefId, out Guid id))
            {
                    var incomes = await _context.Industries
                        .Where(o => o.Fief.FiefId == id && typeof(Income) == o.GetType())
                        .ProjectTo<IncomeLookupDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                    var vm = new GetIncomesListVm
                    {
                        Incomes = incomes
                    };

                    return vm;

                throw new CustomException($"GetDetailedIncomeQuery >> Unauthorized!");
            }

            throw new CustomException($"GetDetailedIncomeQuery >> Could not parse FiefId({request.FiefId}).");
        }
    }

    public class GetIncomesListVm
    {
        public List<IncomeLookupDto> Incomes { get; set; }
    }

    public class IncomeLookupDto : IMapFrom<Income>
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
            profile.CreateMap<Income, IncomeLookupDto>()
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