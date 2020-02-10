using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Subsidiaries.Commands.DeleteSubsidiary
{
    public class DeleteSubsidiaryCommand : IRequest<bool>
    {
        public string IndustryId { get; set; }

        public class Handler : IRequestHandler<DeleteSubsidiaryCommand, bool>
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

            public async Task<bool> Handle(DeleteSubsidiaryCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.IndustryId, out Guid id))
                {
                    var subsidiary = (Subsidiary)await _context.Industries.FindAsync(id);

                    if (subsidiary == null)
                    {
                        throw new CustomException($"DeleteSubsidiaryCommand >> Subsidiary({id}) could not be found!");
                    }

                    var fief = await _context.Fiefs.FindAsync(subsidiary.Fief.FiefId);

                    if (fief == null)
                    {
                        throw new CustomException($"DeleteSubsidiaryCommand >> Fief({subsidiary.Fief.FiefId}) could not be found!");
                    }

                        fief.Industries.Remove(subsidiary);

                        await _context.SaveChangesAsync(cancellationToken);

                        return true;

                    throw new CustomException($"DeleteSubsidiaryCommand >> Unauthorized!");
                }

                throw new CustomException($"DeleteSubsidiaryCommand >> Could not parse IndustryId({request.IndustryId}).");
            }
        }
    }
}