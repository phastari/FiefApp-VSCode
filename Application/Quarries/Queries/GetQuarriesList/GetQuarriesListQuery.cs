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

namespace Application.Quarrys.Queries.GetQuarrysList
{
    public class GetQuarrysListQuery : IRequest<GetQuarrysListVm>
    {
        public string FiefId { get; set; }
    }

    public class GetQuarrysListQueryHandler : IRequestHandler<GetQuarrysListQuery, GetQuarrysListVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _user;

        public GetQuarrysListQueryHandler(IFiefAppDbContext context, IMapper mapper, ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _user = currentUser.GetCurrentUsername();
        }

        public async Task<GetQuarrysListVm> Handle(GetQuarrysListQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.FiefId, out Guid id))
            {
                    var incomes = await _context.Industries
                        .Where(o => o.Fief.FiefId == id && typeof(Quarry) == o.GetType())
                        .ProjectTo<QuarryLookupDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                    var vm = new GetQuarrysListVm
                    {
                        Incomes = incomes
                    };

                    return vm;

                throw new CustomException($"GetDetailedIncomeQuery >> Unauthorized!");
            }

            throw new CustomException($"GetDetailedIncomeQuery >> Could not parse FiefId({request.FiefId}).");
        }
    }

    public class GetQuarrysListVm
    {
        public List<QuarryLookupDto> Incomes { get; set; }
    }

    public class QuarryLookupDto : IMapFrom<Quarry>
    {
        public Guid IndustryId { get; set; }
        public string Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Quarry, QuarryLookupDto>()
                .ForMember(d => d.IndustryId, opt => opt.MapFrom(s => s.IndustryId))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type));
        }
    }
}