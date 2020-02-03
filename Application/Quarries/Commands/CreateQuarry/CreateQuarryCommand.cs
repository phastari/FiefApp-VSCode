using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Quarries.Commands.CreateQuarry
{
    public class CreateQuarryCommand : IRequest<bool>
    {
        public string FiefId { get; set; }
        public int QuarryTypeId { get; set; }
        public int YearsLeft { get; set; }

        public class Handler : IRequestHandler<CreateQuarryCommand, bool>
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

            public async Task<bool> Handle(CreateQuarryCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.FiefId, out Guid id))
                {
                    var fief = await _context.Fiefs.FindAsync(id);

                    var helper = new GetUserNameFromFiefId(_context);
                    if (await helper.Check(fief.FiefId, _user))
                    {
                        var quarry = new Quarry
                        {
                            Fief = fief,
                            QuarryTypeId = request.QuarryTypeId,
                            IsFirstYear = true,
                            IsBeingDeveloped = false,
                            YearsLeft = request.YearsLeft
                        };

                        fief.Industries.Add(quarry);

                        await _context.SaveChangesAsync(cancellationToken);

                        return true;
                    }

                    throw new CustomException($"CreateQuarryCommand >> Unauthorized!");
                }

                throw new CustomException($"CreateQuarryCommand >> Could not parse FiefId({request.FiefId}).");
            }
        }
    }
}