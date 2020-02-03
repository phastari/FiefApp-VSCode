using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Villages.Commands.CreateVillage
{
    public class CreateVillageCommand : IRequest<bool>
    {
        public string FiefId { get; set; }

        public class Handler : IRequestHandler<CreateVillageCommand, bool>
        {
            private readonly IFiefAppDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IFiefAppDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<bool> Handle(CreateVillageCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.FiefId, out Guid id))
                {
                    var fief = await _context.Fiefs.FindAsync(id);

                    var count = fief.Villages.Count;
                    fief.Villages.Add(new Village { Name = $"By{count}" });

                    await _context.SaveChangesAsync(cancellationToken);

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}