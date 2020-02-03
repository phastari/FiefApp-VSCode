using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmedPassword { get; set; }
        public string Email { get; set; }

        public class Handler : IRequestHandler<UpdateUserCommand, bool>
        {
            private readonly IUserManagerService _userManager;
            private readonly string _userName;
            private readonly IMediator _mediator;

            public Handler(IMediator mediator, IUserManagerService userManager, ICurrentUserService currentUser)
            {
                _mediator = mediator;
                _userManager = userManager;
                _userName = currentUser.GetCurrentUsername();
            }

            public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                if (request.NewPassword != null)
                {
                    var result = await _userManager.ChangePasswordAsync(_userName, request.OldPassword, request.NewPassword);

                    if (request.Email != null)
                    {
                        var emailResult = await _userManager.GenerateChangeEmailTokenAsync(_userName, request.Email);

                        if (emailResult.Succeeded)
                        {
                            return true;
                        }

                        return false;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(request.Email))
                    {
                        var emailResult = await _userManager.GenerateChangeEmailTokenAsync(_userName, request.Email);

                        if (emailResult.Succeeded)
                        {
                            return true;
                        }

                        return false;
                    }
                }

                return false;
            }
        }
    }
}