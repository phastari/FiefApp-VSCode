using System.Threading.Tasks;
using Application.Fiefs.Commands.CreateFief;
using Application.Fiefs.Commands.DeleteFief;
using Application.Fiefs.Commands.UpdateFief;
using Application.Fiefs.Queries.GetFief;
using Application.Fiefs.Queries.InitializeFief;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FiefController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFiefCommand command)
        {
            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery(Name = "0")] string fiefId)
        {
            var vm = await Mediator.Send(new DeleteFiefCommand() { FiefId = fiefId });

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateFiefCommand command)
        {
            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery(Name = "0")] string fiefId)
        {
            var vm = await Mediator.Send(new GetFiefQuery() { FiefId = fiefId });

            return Ok(vm.Fief);
        }

        [HttpGet]
        public async Task<IActionResult> Init([FromQuery(Name = "0")] string gameSessionId)
        {
            var vm = await Mediator.Send(new InitializeFiefQuery() { GameSessionId = gameSessionId });

            return Ok(vm);
        }
    }
}