using System.Threading.Tasks;
using cart_api.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cart_api.Controllers
{
    [ApiController]
    [Route("api/variant")]
    public class VariantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VariantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("variants")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetVariantsQuery());
            return Ok(result);
        }
        
        [HttpPost("variants")]
        public async Task<IActionResult> Add(AddVariantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}