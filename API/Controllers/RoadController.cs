using System.Threading.Tasks;
using Application.Roads.Commands.UpdateRoad;
using Application.Roads.Queries.GetDetailedRoad;
using Application.Roads.Queries.GetRoadsList;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RoadController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateRoadCommand command)
        {
            var succeeded = await Mediator.Send(command);

            return Ok(succeeded);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoad([FromBody] GetDetailedRoadQuery query)
        {
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoadsList([FromBody] GetRoadsListQuery query)
        {
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}