using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public string UserName { get; set; }

        public class Handler : IRequestHandler<DeleteUserCommand, bool>
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

            public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                if (request.UserName == _user)
                {
                    var deleted = await _userManager.DeleteUserAsync(request.UserName);

                    if (deleted.Succeeded)
                    {
                        return true;
                    }

                    throw new CustomException($"DeleteUserCommand >> UserManager.DeleteUserAsync({request.UserName}) failed.");
                }

                throw new CustomException($"DeleteUserCommand >> Unauthorized!");
            }
        }
    }
}