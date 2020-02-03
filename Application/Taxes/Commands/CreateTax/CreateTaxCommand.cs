using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Taxes.Commands.CreateTax
{
    public class CreateTaxCommand : IRequest<bool>
    {
        public string FiefId { get; set; }
        public string TaxName { get; set; }

        public class Handler : IRequestHandler<CreateTaxCommand, bool>
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

            public async Task<bool> Handle(CreateTaxCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.FiefId, out Guid id))
                {
                    var fief = await _context.Fiefs.FindAsync(id);

                    if (fief == null)
                    {
                        throw new CustomException($"CreateTaxCommand >> Could not find Fief({fief.FiefId}).");
                    }

                    var helper = new GetUserNameFromFiefId(_context);
                    if (await helper.Check(fief.FiefId, _user))
                    {
                        var tax = new Tax
                        {
                            Name = request.TaxName
                        };

                        fief.Industries.Add(tax);

                        await _context.SaveChangesAsync(cancellationToken);

                        return true;
                    }

                    throw new CustomException($"CreateTaxCommand >> Unauthorized!");
                }

                throw new CustomException($"CreateTaxCommand >> Could not parse FiefId({request.FiefId}).");
            }
        }
    }
}