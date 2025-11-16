using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Order.MicroService.API.Controllers;

[ApiController, Route("api/order/status")]
public class OrderStatusController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet()]
    public async Task<ActionResult> GetAllOrderStatuses(CancellationToken cancellationToken)
    {
        var model = new GetAllOrderStatusesQuery();
        var ress = await _mediator.Send(model, cancellationToken);
        return Ok(ress);
    }
}
