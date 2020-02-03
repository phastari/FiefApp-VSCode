using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Villages.Commands.DeleteVillage
{
    public class DeleteVillageCommand : IRequest<bool>
    {
        public string FiefId { get; set; }
        public string VillageId { get; set; }

        public class Handler : IRequestHandler<DeleteVillageCommand, bool>
        {
            private readonly IFiefAppDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IFiefAppDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<bool> Handle(DeleteVillageCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.VillageId, out Guid villageId) && Guid.TryParse(request.FiefId, out Guid fiefId))
                {
                    var village = await _context.Villages.FindAsync(villageId);
                    var fief = await _context.Fiefs.FindAsync(fiefId);

                    fief.Villages.Remove(village);
                    _context.Villages.Remove(village);

                    await _context.SaveChangesAsync(cancellationToken);

                    return true;
                }

                return false;
            }
        }
    }
}