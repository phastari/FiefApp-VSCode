using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Fiefs.Commands.DeleteFief
{
    public class DeleteFiefCommand : IRequest<bool>
    {
        public string FiefId { get; set; }

        public class Handler : IRequestHandler<DeleteFiefCommand, bool>
        {
            private readonly IFiefAppDbContext _context;
            private readonly IMediator _mediator;
            private readonly string _user;

            public Handler(IFiefAppDbContext context, IMediator mediator, ICurrentUserService userService)
            {
                _context = context;
                _mediator = mediator;
                _user = userService.GetCurrentUsername();
            }

            public async Task<bool> Handle(DeleteFiefCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.FiefId, out Guid id))
                {
                    var fief = await _context.Fiefs.FindAsync(id);

                    if (fief != null)
                    {
                        _context.Fiefs.Remove(fief);
                        await _context.SaveChangesAsync(cancellationToken);

                        return true;
                    }

                    // FiefId could not be found!");
                    return false;
                }
                else
                {
                    // Could not parse FiefId to a valid Guid.
                    return false;
                }
            }
        }
    }
}