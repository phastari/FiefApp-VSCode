using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Taxes.Queries.GetDetailedTax
{
    public class GetDetailedTaxQuery : IRequest<GetDetailedTaxVm>
    {
        public string IndustryId { get; set; }
    }

    public class GetDetailedTaxQueryHandler : IRequestHandler<GetDetailedTaxQuery, GetDetailedTaxVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _user;

        public GetDetailedTaxQueryHandler(IFiefAppDbContext context, IMapper mapper, ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _user = currentUser.GetCurrentUsername();
        }

        public async Task<GetDetailedTaxVm> Handle(GetDetailedTaxQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.IndustryId, out Guid id))
            {
                var tax = (Tax)await _context.Industries.FindAsync(id);

                if (tax == null)
                {
                    throw new CustomException($"GetDetailedTaxQuery >> Could not find Tax({request.IndustryId}).");
                }

                    var vm = new GetDetailedTaxVm
                    {
                        Tax = _mapper.Map<DetailedTaxLookupDto>(tax)
                    };

                    return vm;

                throw new CustomException($"GetDetailedIncomeQuery >> Unauthorized!");
            }

            throw new CustomException($"GetDetailedIncomeQuery >> Could not parse IndustryId({request.IndustryId}).");
        }
    }

    public class GetDetailedTaxVm
    {
        public DetailedTaxLookupDto Tax { get; set; }
    }

    public class DetailedTaxLookupDto : IMapFrom<Income>
    {
        public Guid IndustryId { get; set; }
        public string Name { get; set; }
        public int NumberOfBailiffs { get; set; }
        public int Silver { get; set; }
        public int Base { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tax, DetailedTaxLookupDto>()
                .ForMember(d => d.IndustryId, opt => opt.MapFrom(s => s.IndustryId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.NumberOfBailiffs, opt => opt.MapFrom(s => s.NumberOfBailiffs))
                .ForMember(d => d.Silver, opt => opt.MapFrom(s => s.Silver))
                .ForMember(d => d.Base, opt => opt.MapFrom(s => s.Base));
        }
    }
}