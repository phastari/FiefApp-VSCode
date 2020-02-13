using System.Threading.Tasks;
using Application.Stewards.Commands.CreateSteward;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StewardController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStewardCommand command)
        {
            var succeeded = await Mediator.Send(command);

            return Ok(succeeded);
        }
    }
}