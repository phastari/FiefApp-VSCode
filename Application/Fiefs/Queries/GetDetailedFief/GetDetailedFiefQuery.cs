using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.Fiefs.Queries.GetDetailedFief
{
    public class GetDetailedFiefQuery : IRequest<GetDetailedFiefsListVm>
    {
        public string FiefId { get; set; }
    }

    public class GetDetailedFiefQueryHandler : IRequestHandler<GetDetailedFiefQuery, GetDetailedFiefsListVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _currentUser;

        public GetDetailedFiefQueryHandler(IFiefAppDbContext context, ICurrentUserService currentUser, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser.GetCurrentUsername();
        }

        public async Task<GetDetailedFiefsListVm> Handle(GetDetailedFiefQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.FiefId, out Guid id))
            {
                var fief = await _context.Fiefs.FindAsync(id);

                if (fief != null) 
                {
                    var vm = new GetDetailedFiefsListVm
                    {
                        Fief = _mapper.Map<DetailedFiefLookupDto>(fief)
                    };

                    return vm;
                } else 
                {
                    throw new CustomException($"GetDetailedFiefQuery >> Could not find fief ({request.FiefId}).");
                }
            }

            throw new CustomException($"GetDetailedFiefQuery >> Could not parse ({request.FiefId}).");
        }
    }

    public class GetDetailedFiefsListVm
    {
        public DetailedFiefLookupDto Fief { get; set; }
    }
}