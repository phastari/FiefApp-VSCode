using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserVm>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string Email { get; set; }

        public class Handler : IRequestHandler<CreateUserCommand, CreateUserVm>
        {
            private readonly IFiefAppDbContext _context;
            private readonly IUserManagerService _userManager;
            private readonly IMediator _mediator;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(IFiefAppDbContext context, IMediator mediator, IUserManagerService userManager, IJwtGenerator jwtGenerator)
            {
                _context = context;
                _mediator = mediator;
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
            }

            public async Task<CreateUserVm> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var vm = new CreateUserVm();

                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user == null)
                {
                    var created = await _userManager.CreateUserAsync(request.UserName, request.Password, request.Email);

                    if (created)
                    {
                        await _context.UserLinks.AddAsync(new UserLink { UserName = request.UserName });
                        await _context.SaveChangesAsync(cancellationToken);

                        var addedUser = await _userManager.FindByNameAsync(request.UserName);

                        vm.Token = _jwtGenerator.CreateToken(addedUser);
                        vm.Username = addedUser.UserName;

                        return vm;
                    }

                    vm.Error = "Passwords did not match!";
                    return vm;
                }

                vm.Error = "The user already exists!";
                return vm;
            }
        }
    }

    public class CreateUserVm
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string Error { get; set; }
    }
}