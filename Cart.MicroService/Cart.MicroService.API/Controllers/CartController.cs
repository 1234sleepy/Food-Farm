using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cart.MicroService.API.Controllers;

[ApiController, Route("api/cart")]
public class CartController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult> CreateCart([FromBody]  model,
    CancellationToken cancellationToken)
    {
        return Ok();
    }
}
