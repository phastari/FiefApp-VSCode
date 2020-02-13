using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.GameSessions.Queries.GetGameSessionsList
{
    public class GetGameSessionsListQuery : IRequest<GetGameSessionsListVm>
    {
    }

    public class GetGameSessionsListQueryHandler : IRequestHandler<GetGameSessionsListQuery, GetGameSessionsListVm>
    {
        private readonly IUserManagerService _userManager;
        private readonly IFiefAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _currentUser;

        public GetGameSessionsListQueryHandler(IUserManagerService userManager, ICurrentUserService currentUser, IFiefAppDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser.GetCurrentUsername();
        }

        public async Task<GetGameSessionsListVm> Handle(GetGameSessionsListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.GameSessions
                .Where(o => o.User == _currentUser)
                .ProjectTo<GameSessionLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new GetGameSessionsListVm
            {
                GameSessions = entities
            };

            return vm;
        }
    }

    public class GetGameSessionsListVm
    {
        public List<GameSessionLookupDto> GameSessions { get; set; }
    }

    public class GameSessionLookupDto : IMapFrom<GameSession>
    {
        public Guid GameSessionId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUsed { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GameSession, GameSessionLookupDto>()
                .ForMember(d => d.GameSessionId, opt => opt.MapFrom(s => s.GameSessionId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created))
                .ForMember(d => d.LastUsed, opt => opt.MapFrom(s => s.LastUsed));
        }
    }
}