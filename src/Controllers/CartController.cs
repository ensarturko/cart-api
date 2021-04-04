using System;
using System.Threading.Tasks;
using cart_api.Domain.Commands;
using cart_api.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cart_api.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-to-cart")]
        public async Task<IActionResult> Add(AddToCartCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
        [HttpGet("cart-item")]
        public async Task<IActionResult> Get(Guid cartGuid)
        {
            var result = await _mediator.Send(new GetCartItemsQuery {CartGuid = cartGuid});
            return Ok(result);
        }
        
        [HttpGet("all-cart-items")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetCartContentsQuery());
            return Ok(result);
        }
    }
}