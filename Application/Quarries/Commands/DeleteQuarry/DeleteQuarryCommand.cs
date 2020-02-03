using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Quarries.Commands.DeleteQuarry
{
    public class DeleteQuarryCommand : IRequest<bool>
    {
        public string IndustryId { get; set; }

        public class Handler : IRequestHandler<DeleteQuarryCommand, bool>
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

            public async Task<bool> Handle(DeleteQuarryCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.IndustryId, out Guid id))
                {
                    var quarry = (Quarry)await _context.Industries.FindAsync(id);

                    if (quarry == null)
                    {
                        throw new CustomException($"DeleteQuarryCommand >> Quarry({id}) could not be found!");
                    }

                    var fief = await _context.Fiefs.FindAsync(quarry.Fief.FiefId);

                    if (fief == null)
                    {
                        throw new CustomException($"DeleteQuarryCommand >> Fief({quarry.Fief.FiefId}) could not be found!");
                    }

                    var helper = new GetUserNameFromFiefId(_context);
                    if (await helper.Check(fief.FiefId, _user))
                    {
                        fief.Industries.Remove(quarry);

                        await _context.SaveChangesAsync(cancellationToken);

                        return true;
                    }

                    throw new CustomException($"DeleteQuarryCommand >> Unauthorized!");
                }

                throw new CustomException($"DeleteQuarryCommand >> Could not parse IndustryId({request.IndustryId}).");
            }
        }
    }
}