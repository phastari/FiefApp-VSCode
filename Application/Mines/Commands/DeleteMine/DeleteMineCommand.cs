using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Mines.Commands.DeleteMine
{
    public class DeleteMineCommand : IRequest<bool>
    {
        public string IndustryId { get; set; }

        public class Handler : IRequestHandler<DeleteMineCommand, bool>
        {
            private readonly IFiefAppDbContext _context;
            private readonly IUserManagerService _userManager;
            private readonly IMediator _mediator;
            private readonly string _user;

            public Handler(IFiefAppDbContext context, IMediator mediator, IUserManagerService userManager, ICurrentUserService currentUser)
            {
                _context = context;
                _mediator = mediator;
                _userManager = userManager;
                _user = currentUser.GetCurrentUsername();
            }

            public async Task<bool> Handle(DeleteMineCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.IndustryId, out Guid id))
                {
                    var mine = (Mine)await _context.Industries.FindAsync(id);

                    throw new CustomException($"DeleteMineCommand >> Unauthorized!");
                }

                throw new CustomException($"DeleteMineCommand >> Could not parse IndustryId({request.IndustryId}).");
            }
        }
    }
}