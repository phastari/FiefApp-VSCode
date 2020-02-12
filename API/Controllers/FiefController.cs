using System;
using System.Threading.Tasks;
using Application.Fiefs.Commands.CreateFief;
using Application.Fiefs.Commands.DeleteFief;
using Application.Fiefs.Commands.UpdateFief;
using Application.Fiefs.Queries.GetDetailedFief;
using Application.Fiefs.Queries.GetFiefsList;
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
        public async Task<IActionResult> Delete([FromBody] DeleteFiefCommand command)
        {
            var vm = await Mediator.Send(command);

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
            var vm = await Mediator.Send(new GetDetailedFiefQuery() { FiefId = fiefId });

            return Ok(vm.Fief);
        }

        [HttpGet]
        public async Task<IActionResult> Init([FromQuery(Name = "0")] string gameSessionId)
        {
            var vm = await Mediator.Send(new GetFiefsListQuery() { GameSessionId = gameSessionId });

            return Ok(vm);
        }
    }
}