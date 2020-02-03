using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Fellings.Commands.CreateFelling
{
    // NOT NEEDED!!!
    public class CreateFellingCommand : IRequest<bool>
    {
        public string FiefId { get; set; }

        public class Handler : IRequestHandler<CreateFellingCommand, bool>
        {
            private readonly IFiefAppDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IFiefAppDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<bool> Handle(CreateFellingCommand request, CancellationToken cancellationToken)
            {
                var fief = _context.Fiefs.Where(o => o.FiefId.ToString() == request.FiefId).First();

                if (fief != null)
                {
                    var felling = new Felling();

                    fief.Industries.Add(felling);

                    await _context.SaveChangesAsync(cancellationToken);

                    return true;
                }

                return false;
            }
        }
    }
}