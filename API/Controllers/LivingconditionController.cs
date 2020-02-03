using System.Threading.Tasks;
using Application.Livingconditions.Commands.UpdateLivingcondition;
using Application.Livingconditions.Queries.GetDetailedLivingcondition;
using Application.Livingconditions.Queries.GetLivingconditionsListQuery;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LivingconditionController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateLivingconditionCommand command)
        {
            var succeeded = await Mediator.Send(command);

            return Ok(succeeded);
        }

        [HttpGet]
        public async Task<IActionResult> GetLivingcondition([FromBody] GetDetailedLivingconditionQuery query)
        {
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet]
        public async Task<IActionResult> GetLivingconditionsList([FromBody] GetLivingconditionsListQuery query)
        {
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}