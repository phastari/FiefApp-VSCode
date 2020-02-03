using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Fellings.Commands.DeleteFelling
{
    // NOT NEEDED!!!
    public class DeleteFellingCommand : IRequest<bool>
    {
        public string IndustryId { get; set; }

        public class Handler : IRequestHandler<DeleteFellingCommand, bool>
        {
            private readonly IFiefAppDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IFiefAppDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<bool> Handle(DeleteFellingCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.IndustryId, out Guid id))
                {
                    var industry = await _context.Industries.FindAsync(id);

                    _context.Industries.Remove(industry);

                    await _context.SaveChangesAsync(cancellationToken);

                    return true;
                }

                return false;
            }
        }
    }
}