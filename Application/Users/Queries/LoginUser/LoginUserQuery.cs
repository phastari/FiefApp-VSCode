using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Users.Queries.LoginUser
{
    public class LoginUserQuery : IRequest<CurrentUserVm>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, CurrentUserVm>
    {
        private readonly IUserManagerService _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public LoginUserQueryHandler(IUserManagerService userManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<CurrentUserVm> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var vm = new CurrentUserVm();

            var user = await _userManager.FindByNameAsync(request.Username);

            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user.UserName, request.Password);

                if (result != "")
                {
                    vm.Username = user.UserName;
                    vm.Token = result;
                }
                else
                {
                    vm.Error = "Wrong password!";
                    vm.Username = "";
                    vm.Token = "";
                }
            }
            else
            {
                vm.Error = "User does not exist!";
                vm.Username = "";
                vm.Token = "";
            }

            return vm;
        }
    }
}