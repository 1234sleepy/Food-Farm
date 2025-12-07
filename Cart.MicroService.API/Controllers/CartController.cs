using Cart.MicroService.Domain.UseCases.CreateCart;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cart.MicroService.API.Controllers;

[ApiController, Route("api/cart")]
public class CartController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult> UpdateCart([FromBody] UpdateCartCommand model,
    CancellationToken cancellationToken)
    {
        await _mediator.Send(model, cancellationToken);
        return Ok();
    }
}
