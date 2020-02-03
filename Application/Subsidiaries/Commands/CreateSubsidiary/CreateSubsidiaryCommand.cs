using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Subsidiaries.Commands.CreateSubsidiary
{
    public class CreateSubsidiaryCommand : IRequest<bool>
    {
        public string FiefId { get; set; }
        public int Quality { get; set; }
        public int DevelopmentLevel { get; set; }
        public int SubsidiaryTypeId { get; set; }

        public class Handler : IRequestHandler<CreateSubsidiaryCommand, bool>
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

            public async Task<bool> Handle(CreateSubsidiaryCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.FiefId, out Guid id))
                {
                    var fief = await _context.Fiefs.FindAsync(id);

                    var helper = new GetUserNameFromFiefId(_context);
                    if (await helper.Check(fief.FiefId, _user))
                    {
                        var subsidiary = new Subsidiary
                        {
                            Fief = fief,
                            SubsidiaryTypeId = request.SubsidiaryTypeId,
                            Quality = request.Quality,
                            IsBeingDeveloped = false
                        };

                        fief.Industries.Add(subsidiary);

                        await _context.SaveChangesAsync(cancellationToken);

                        return true;
                    }

                    throw new CustomException($"CreateSubsidiaryCommand >> Unauthorized!");
                }

                throw new CustomException($"CreateSubsidiaryCommand >> Could not parse FiefId({request.FiefId}).");
            }
        }
    }
}