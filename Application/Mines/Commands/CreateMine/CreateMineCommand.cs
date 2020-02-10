using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Mines.Commands.CreateMine
{
    public class CreateMineCommand : IRequest<bool>
    {
        public string FiefId { get; set; }
        public int MineTypeId { get; set; }
        public int YearsLeft { get; set; }

        public class Handler : IRequestHandler<CreateMineCommand, bool>
        {
            private readonly IFiefAppDbContext _context;
            private readonly IMediator _mediator;
            private readonly string _user;

            public Handler(IFiefAppDbContext context, IMediator mediator, ICurrentUserService currentUser)
            {
                _context = context;
                _mediator = mediator;
                _user = currentUser.GetCurrentUsername();
            }

            public async Task<bool> Handle(CreateMineCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.FiefId, out Guid id))
                {
                    var fief = await _context.Fiefs.FindAsync(id);
                    
                        var mine = new Mine
                        {
                            Fief = fief,
                            MineTypeId = request.MineTypeId,
                            FirstYear = true,
                            IsBeingDeveloped = false
                        };

                        fief.Industries.Add(mine);

                        await _context.SaveChangesAsync(cancellationToken);

                        return true;

                    throw new CustomException($"CreateMineCommand >> Unauthorized!");
                }

                throw new CustomException($"CreateMineCommand >> Could not parse FiefId({request.FiefId}).");
            }
        }
    }
}