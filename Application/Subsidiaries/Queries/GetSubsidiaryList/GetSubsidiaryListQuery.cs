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

namespace Application.Subsidiarys.Queries.GetSubsidiarysList
{
    public class GetSubsidiarysListQuery : IRequest<GetSubsidiarysListVm>
    {
        public string FiefId { get; set; }
    }

    public class GetSubsidiarysListQueryHandler : IRequestHandler<GetSubsidiarysListQuery, GetSubsidiarysListVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _user;

        public GetSubsidiarysListQueryHandler(IFiefAppDbContext context, IMapper mapper, ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _user = currentUser.GetCurrentUsername();
        }

        public async Task<GetSubsidiarysListVm> Handle(GetSubsidiarysListQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.FiefId, out Guid id))
            {
                    var subsidiaries = await _context.Industries
                        .Where(o => o.Fief.FiefId == id && typeof(Subsidiary) == o.GetType())
                        .ProjectTo<SubsidiaryLookupDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                    var vm = new GetSubsidiarysListVm
                    {
                        Subsidiaries = subsidiaries
                    };

                    return vm;

                throw new CustomException($"GetDetailedIncomeQuery >> Unauthorized!");
            }

            throw new CustomException($"GetDetailedIncomeQuery >> Could not parse FiefId({request.FiefId}).");
        }
    }

    public class GetSubsidiarysListVm
    {
        public List<SubsidiaryLookupDto> Subsidiaries { get; set; }
    }

    public class SubsidiaryLookupDto : IMapFrom<Subsidiary>
    {
        public Guid IndustryId { get; set; }
        public string Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Subsidiary, SubsidiaryLookupDto>()
                .ForMember(d => d.IndustryId, opt => opt.MapFrom(s => s.IndustryId))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.SubsidiaryType.Type));
        }
    }
}