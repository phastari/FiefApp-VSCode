using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Taxes.Commands.DeleteTax
{
    public class DeleteTaxCommand : IRequest<bool>
    {
        public string IndustryId { get; set; }

        public class Handler : IRequestHandler<DeleteTaxCommand, bool>
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

            public async Task<bool> Handle(DeleteTaxCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.IndustryId, out Guid id))
                {
                    var tax = (Tax)await _context.Industries.FindAsync(id);

                    if (tax == null)
                    {
                        throw new CustomException($"DeleteTaxCommand >> Tax({id}) could not be found!");
                    }

                    var fief = await _context.Fiefs.FindAsync(tax.Fief.FiefId);

                    if (fief == null)
                    {
                        throw new CustomException($"DeleteTaxCommand >> Fief({tax.Fief.FiefId}) could not be found!");
                    }

                        fief.Industries.Remove(tax);

                        await _context.SaveChangesAsync(cancellationToken);

                        return true;

                    throw new CustomException($"DeleteTaxCommand >> Unauthorized!");
                }

                throw new CustomException($"DeleteTaxCommand >> Could not parse IndustryId({request.IndustryId}).");
            }
        }
    }
}