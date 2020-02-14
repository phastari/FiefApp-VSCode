using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.Fiefs.Queries.GetFief
{
    public class GetFiefQuery : IRequest<GetFiefsListVm>
    {
        public string FiefId { get; set; }
    }

    public class GetFiefQueryHandler : IRequestHandler<GetFiefQuery, GetFiefsListVm>
    {
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _currentUser;

        public GetFiefQueryHandler(IFiefAppDbContext context, ICurrentUserService currentUser, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser.GetCurrentUsername();
        }

        public async Task<GetFiefsListVm> Handle(GetFiefQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.FiefId, out Guid id))
            {
                var fief = await _context.Fiefs.FindAsync(id);

                if (fief != null) 
                {
                    var vm = new GetFiefsListVm
                    {
                        Fief = _mapper.Map<FiefLookupDto>(fief)
                    };

                    return vm;
                } 
                else 
                {
                    // Could not find fief.
                    return null;
                }
            }

            // Could not parse request.FiefId.
            return null;
        }
    }

    public class GetFiefsListVm
    {
        public FiefLookupDto Fief { get; set; }
    }
}