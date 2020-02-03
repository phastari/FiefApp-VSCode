using System;
using System.Threading.Tasks;
using Application.GameSessions.Commands.CreateGameSession;
using Application.GameSessions.Commands.DeleteGameSession;
using Application.GameSessions.Commands.UpdateGameSession;
using Application.GameSessions.Queries.GetGameSessionsList;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GameSessionController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var id = await Mediator.Send(new CreateGameSessionCommand());

            return Ok(new { res = id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteGameSessionCommand command)
        {
            var succeeded = await Mediator.Send(command);

            return Ok(new { succeeded = succeeded });
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateGameSessionCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetGameSessions()
        {
            var result = await Mediator.Send(new GetGameSessionsListQuery());

            return Ok(result.GameSessions);
        }
    }
}