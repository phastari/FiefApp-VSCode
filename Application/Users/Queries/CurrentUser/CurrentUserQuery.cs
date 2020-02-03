using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Users.Queries.CurrentUser
{
    public class CurrentUserQuery : IRequest<CurrentUserVm> { }

    public class CurrentUserQueryHandler : IRequestHandler<CurrentUserQuery, CurrentUserVm>
    {
        private readonly IUserManagerService _userManager;
        private readonly string _currentUser;

        public CurrentUserQueryHandler(IUserManagerService userManager, ICurrentUserService currentUser)
        {
            _userManager = userManager;
            _currentUser = currentUser.GetCurrentUsername();
        }

        public async Task<CurrentUserVm> Handle(CurrentUserQuery request, CancellationToken cancellationToken)
        {
            var vm = new CurrentUserVm();

            if (string.IsNullOrEmpty(_currentUser))
            {
                vm.Username = "";
            }
            else
            {
                var found = await _userManager.FindByNameAsync(_currentUser);

                if (found.UserName == _currentUser)
                {
                    vm.Username = _currentUser;
                }
                else
                {
                    vm.Username = "";
                }
            }

            return vm;
        }
    }
}