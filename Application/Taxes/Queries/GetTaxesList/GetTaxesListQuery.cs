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

namespace Application.Taxs.Queries.GetTaxsList
{
    public class GetTaxsListQuery : IRequest<GetTaxsListVm>
    {
        public string FiefId { get; set; }
    }

    public class GetTaxsListQueryHandler : IRequestHandler<GetTaxsListQuery, GetTaxsListVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _user;

        public GetTaxsListQueryHandler(IFiefAppDbContext context, IMapper mapper, ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _user = currentUser.GetCurrentUsername();
        }

        public async Task<GetTaxsListVm> Handle(GetTaxsListQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.FiefId, out Guid id))
            {
                    var taxes = await _context.Industries
                        .Where(o => o.Fief.FiefId == id && typeof(Tax) == o.GetType())
                        .ProjectTo<TaxLookupDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                    var vm = new GetTaxsListVm
                    {
                        Taxes = taxes
                    };

                    return vm;

                throw new CustomException($"GetDetailedIncomeQuery >> Unauthorized!");
            }

            throw new CustomException($"GetDetailedIncomeQuery >> Could not parse FiefId({request.FiefId}).");
        }
    }

    public class GetTaxsListVm
    {
        public List<TaxLookupDto> Taxes { get; set; }
    }

    public class TaxLookupDto : IMapFrom<Tax>
    {
        public Guid IndustryId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tax, TaxLookupDto>()
                .ForMember(d => d.IndustryId, opt => opt.MapFrom(s => s.IndustryId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}