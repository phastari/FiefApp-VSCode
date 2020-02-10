using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Industries;
using MediatR;

namespace Application.Incomes.Commands.DeleteIncome
{
    public class DeleteIncomeCommand : IRequest<bool>
    {
        public string IndustryId { get; set; }

        public class Handler : IRequestHandler<DeleteIncomeCommand, bool>
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

            public async Task<bool> Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.IndustryId, out Guid id))
                {
                    var income = (Income)await _context.Industries.FindAsync(id);

                    throw new CustomException($"DeleteIncomeCommand >> Unauthorized!");
                }

                throw new CustomException($"DeleteIncomeCommand >> Could not parse IndustryId({request.IndustryId}).");
            }
        }
    }
}