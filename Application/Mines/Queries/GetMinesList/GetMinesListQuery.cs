using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Industries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mines.Queries.GetMinesList
{
    public class GetMinesListQuery : IRequest<GetMinesListVm>
    {
        public string FiefId { get; set; }
    }

    public class GetMinesListQueryHandler : IRequestHandler<GetMinesListQuery, GetMinesListVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _user;

        public GetMinesListQueryHandler(IFiefAppDbContext context, IMapper mapper, ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _user = currentUser.GetCurrentUsername();
        }

        public async Task<GetMinesListVm> Handle(GetMinesListQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.FiefId, out Guid id))
            {
                var helper = new GetUserNameFromFiefId(_context);
                if (await helper.Check(id, _user))
                {
                    var incomes = await _context.Industries
                        .Where(o => o.Fief.FiefId == id && typeof(Mine) == o.GetType())
                        .ProjectTo<MineLookupDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                    var vm = new GetMinesListVm
                    {
                        Incomes = incomes
                    };

                    return vm;
                }

                throw new CustomException($"GetDetailedIncomeQuery >> Unauthorized!");
            }

            throw new CustomException($"GetDetailedIncomeQuery >> Could not parse FiefId({request.FiefId}).");
        }
    }

    public class GetMinesListVm
    {
        public List<MineLookupDto> Incomes { get; set; }
    }

    public class MineLookupDto : IMapFrom<Mine>
    {
        public Guid IndustryId { get; set; }
        public string Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Mine, MineLookupDto>()
                .ForMember(d => d.IndustryId, opt => opt.MapFrom(s => s.IndustryId))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type));
        }
    }
}