using System.Threading.Tasks;
using Application.Fellings.Commands.UpdateFelling;
using Application.Fellings.Queries.GetDetailedFelling;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FellingController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateFellingCommand command)
        {
            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromBody] GetDetailedFellingQuery query)
        {
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}