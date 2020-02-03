using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Fellings.Commands.UpdateFelling
{
    public class UpdateFellingCommand : IRequest<bool>
    {
        public string FellingId { get; set; }
#nullable enable
        public int? AmountLandclearing { get; set; }
        public int? AmountLandclearingOfFelling { get; set; }
        public int? AmountFelling { get; set; }
        public int? AmountClearUseless { get; set; }
        public bool? IsBeingDeveloped { get; set; }
        public Guid? DevelopmentId { get; set; }
        public Guid? StewardId { get; set; }
#nullable disable

        public class Handler : IRequestHandler<UpdateFellingCommand, bool>
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

            public async Task<bool> Handle(UpdateFellingCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.FellingId, out Guid id))
                {
                    await _context.Industries.FindAsync(id);
                }

                throw new CustomException($"UpdateFellingCommand >> Could not parse FellingId({request.FellingId}).");
            }
        }
    }
}