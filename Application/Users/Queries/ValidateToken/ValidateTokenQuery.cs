using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Users.Queries.ValidateToken
{
    public class ValidateTokenQuery : IRequest<CurrentUserVm>
    {
        public string Token { get; set; }
    }

    public class ValidateTokenQueryHandler : IRequestHandler<ValidateTokenQuery, CurrentUserVm>
    {
        private readonly IUserManagerService _userManager;
        private readonly IJwtGenerator _tokenHandler;

        public ValidateTokenQueryHandler(IUserManagerService userManager, IJwtGenerator tokenHandler)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<CurrentUserVm> Handle(ValidateTokenQuery request, CancellationToken cancellationToken)
        {
            return new CurrentUserVm();
        }
    }
}