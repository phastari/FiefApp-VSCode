using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Persons;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Fiefs.Commands.DeleteFief
{
    public class DeleteFiefCommand : IRequest<bool>
    {
        public string FiefId { get; set; }

        public class Handler : IRequestHandler<DeleteFiefCommand, bool>
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

            public async Task<bool> Handle(DeleteFiefCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.FiefId, out Guid id))
                {
                    var fief = await _context.Fiefs.FindAsync(id);

                    if (fief != null)
                    {
                        _context.Fiefs.Remove(fief);
                        await _context.SaveChangesAsync(cancellationToken);

                        throw new CustomException($"DeleteFiefCommand >> Unauthorized delete!");
                    }

                    throw new CustomException($"DeleteFiefCommand >> Fief({request.FiefId}) could not be found!");
                }
                else
                {
                    throw new CustomException($"DeleteFiefCommand >> Could not parse '{request.FiefId}' to a valid Guid!");
                }
            }
        }
    }
}