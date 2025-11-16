using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Order.MicroService.API.Controllers;

[ApiController, Route("api/order")]
public class OrderController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult> AddOrder([FromBody] AddOrderCommand model,
    CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(model, cancellationToken));
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateOrder(Guid id,
    [FromBody] UpdateOrderCommand model,
    CancellationToken cancellationToken)
    {
        model.Id = id;
        return Ok(await _mediator.Send(model, cancellationToken));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteOrder(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteOrderCommand(id), cancellationToken);
        return Ok();
    }

    [HttpGet()]
    public async Task<ActionResult> GetAllOrders([FromQuery] GetAllOrdersQuery query,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(query, cancellationToken));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetOrder(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetOrderQuery(id), cancellationToken));
    }

    [HttpGet("{phone}")]
    public async Task<ActionResult> GetOrderByPhone(string phone, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetOrderByPhoneQuery(phone), cancellationToken));
    }
}
