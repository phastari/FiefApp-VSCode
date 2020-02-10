using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Mines.Commands.UpdateMine
{
    public class UpdateMineCommand : IRequest<bool>
    {
        public string IndustryId { get; set; }

#nullable enable
        public int? Silver { get; set; }
        public int? Luxury { get; set; }
        public int? Iron { get; set; }
        public int? YearsLeft { get; set; }
        public int? Guards { get; set; }
        public bool? FirstYear { get; set; }
        public bool? IsBeingDeveloped { get; set; }
#nullable disable

        public class Handler : IRequestHandler<UpdateMineCommand, bool>
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

            public async Task<bool> Handle(UpdateMineCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.IndustryId, out Guid id))
                {
                    var mine = (Mine)await _context.Industries.FindAsync(id);

                    if (mine == null)
                    {
                        throw new CustomException($"UpdateQuarryCommand >> Could not find Quarry({id}).");
                    }

                    var fief = await _context.Fiefs.FindAsync(mine.Fief.FiefId);

                    if (fief == null)
                    {
                        throw new CustomException($"UpdateQuarryCommand >> Could not find Fief({mine.Fief.FiefId}).");
                    }

                        if (request.Silver != mine.Silver && request.Silver != null)
                        {
                            mine.Silver = (int)request.Silver;
                        }

                        if (request.Luxury != mine.Luxury && request.Luxury != null)
                        {
                            mine.Luxury = (int)request.Luxury;
                        }

                        if (request.Iron != mine.Iron && request.Iron != null)
                        {
                            mine.Iron = (int)request.Iron;
                        }

                        if (request.YearsLeft != mine.YearsLeft && request.YearsLeft != null)
                        {
                            mine.YearsLeft = (int)request.YearsLeft;
                        }

                        if (request.Guards != mine.Guards && request.Guards != null)
                        {
                            mine.Guards = (int)request.Guards;
                        }

                        if (request.FirstYear != mine.FirstYear && request.FirstYear != null)
                        {
                            mine.FirstYear = (bool)request.FirstYear;
                        }

                        if (request.IsBeingDeveloped != mine.IsBeingDeveloped && request.IsBeingDeveloped != null)
                        {
                            mine.IsBeingDeveloped = (bool)request.IsBeingDeveloped;
                        }

                        await _context.SaveChangesAsync(cancellationToken);
                        return true;

                    throw new CustomException($"UpdateMineCommand >> Unauthorized!");
                }

                throw new CustomException($"UpdateMineCommand >> Could not parse IndustryId({request.IndustryId}).");
            }
        }
    }
}