using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Quarries.Commands.UpdateQuarry
{
    public class UpdateQuarryCommand : IRequest<bool>
    {
        public string IndustryId { get; set; }

#nullable enable
        public string? Type { get; set; }
        public int? Stone { get; set; }
        public int? YearsLeft { get; set; }
        public int? Guards { get; set; }
        public bool? IsFirstYear { get; set; }
        public bool? IsBeingDeveloped { get; set; }
#nullable disable

        public class Handler : IRequestHandler<UpdateQuarryCommand, bool>
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

            public async Task<bool> Handle(UpdateQuarryCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.IndustryId, out Guid id))
                {
                    var quarry = (Quarry)await _context.Industries.FindAsync(id);

                    if (quarry == null)
                    {
                        throw new CustomException($"UpdateQuarryCommand >> Could not find Quarry({id}).");
                    }

                    var fief = await _context.Fiefs.FindAsync(quarry.Fief.FiefId);

                    if (fief == null)
                    {
                        throw new CustomException($"UpdateQuarryCommand >> Could not find Fief({quarry.Fief.FiefId}).");
                    }

                    var helper = new GetUserNameFromFiefId(_context);
                    if (await helper.Check(fief.FiefId, _user))
                    {
                        if (request.Stone != quarry.Stone && request.Stone != null)
                        {
                            quarry.Stone = (int)request.Stone;
                        }

                        if (request.Type != quarry.Type && request.Type != null)
                        {
                            quarry.Type = (string)request.Type;
                        }

                        if (request.YearsLeft != quarry.YearsLeft && request.YearsLeft != null)
                        {
                            quarry.YearsLeft = (int)request.YearsLeft;
                        }

                        if (request.Guards != quarry.Guards && request.Guards != null)
                        {
                            quarry.Guards = (int)request.Guards;
                        }

                        if (request.IsFirstYear != quarry.IsFirstYear && request.IsFirstYear != null)
                        {
                            quarry.IsFirstYear = (bool)request.IsFirstYear;
                        }

                        if (request.IsBeingDeveloped != quarry.IsBeingDeveloped && request.IsBeingDeveloped != null)
                        {
                            quarry.IsBeingDeveloped = (bool)request.IsBeingDeveloped;
                        }

                        await _context.SaveChangesAsync(cancellationToken);
                        return true;
                    }

                    throw new CustomException($"UpdateQuarryCommand >> Unauthorized!");
                }

                throw new CustomException($"UpdateQuarryCommand >> Could not parse IndustryId({request.IndustryId}).");
            }
        }
    }
}