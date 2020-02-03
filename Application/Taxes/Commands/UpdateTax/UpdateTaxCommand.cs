using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Taxes.Commands.UpdateTax
{
    public class UpdateTaxCommand : IRequest<bool>
    {
        public string IndustryId { get; set; }

#nullable enable
        public int? NumberOfBailiffs { get; set; }
        public int? Silver { get; set; }
        public int? Base { get; set; }
        public string? Name { get; set; }
#nullable disable

        public class Handler : IRequestHandler<UpdateTaxCommand, bool>
        {
            private readonly IFiefAppDbContext _context;
            private readonly string _user;
            private readonly IMediator _mediator;

            public Handler(IMediator mediator, ICurrentUserService currentUser, IFiefAppDbContext context)
            {
                _mediator = mediator;
                _user = currentUser.GetCurrentUsername();
                _context = context;
            }

            public async Task<bool> Handle(UpdateTaxCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.IndustryId, out Guid id))
                {
                    var tax = (Tax)await _context.Industries.FindAsync(id);

                    if (tax == null)
                    {
                        throw new CustomException($"UpdateTaxCommand >> Could not find Tax({id}).");
                    }

                    var fief = await _context.Fiefs.FindAsync(tax.Fief.FiefId);

                    if (fief == null)
                    {
                        throw new CustomException($"UpdateTaxCommand >> Could not find Fief({tax.Fief.FiefId}).");
                    }

                    var helper = new GetUserNameFromFiefId(_context);
                    if (await helper.Check(fief.FiefId, _user))
                    {
                        if (request.NumberOfBailiffs != tax.NumberOfBailiffs && request.NumberOfBailiffs != null)
                        {
                            tax.NumberOfBailiffs = (int)request.NumberOfBailiffs;
                        }

                        if (request.Silver != tax.Silver && request.Silver != null)
                        {
                            tax.Silver = (int)request.Silver;
                        }

                        if (request.Name != tax.Name && request.Name != null)
                        {
                            tax.Name = (string)request.Name;
                        }

                        if (request.Base != tax.Base && request.Base != null)
                        {
                            tax.Base = (int)request.Base;
                        }

                        await _context.SaveChangesAsync(cancellationToken);
                        return true;
                    }

                    throw new CustomException($"UpdateTaxCommand >> Unauthorized!");
                }

                throw new CustomException($"UpdateTaxCommand >> Could not parse IndustryId({request.IndustryId}).");
            }
        }
    }
}