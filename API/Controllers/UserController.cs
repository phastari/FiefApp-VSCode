using System;
using System.Threading.Tasks;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.CurrentUser;
using Application.Users.Queries.LoginUser;
using Application.Users.Queries.ValidateToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> CurrentUser()
        {
            var vm = await Mediator.Send(new CurrentUserQuery());

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserQuery query)
        {
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{token}")]
        public async Task<IActionResult> ValidateToken(string token)
        {
            var response = await Mediator.Send(new ValidateTokenQuery { Token = token});

            return Ok(response);
        }
    }
}