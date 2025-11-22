using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Command.AddOrderItem;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Command.DeleteOrderItem;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Command.UpdateOrderItem;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Queries.GetAllOrderItems;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Queries.GetOrderItem;

namespace Order.MicroService.API.Controllers;

[ApiController, Route("api/order/item")]
public class OrderItemController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult> AddOrderItem([FromBody] AddOrderItemCommand model,
    CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(model, cancellationToken));
    }

    [HttpPut()]
    public async Task<ActionResult> UpdateOrderItem(
        [FromBody] UpdateOrderItemCommand model,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(model, cancellationToken));
    }

    [HttpDelete("{productid:guid}+{orderid:guid}")]
    public async Task<ActionResult> DeleteOrderItem(Guid orderid, Guid productid, CancellationToken cancellationToken)
    {

        DeleteOrderItemCommand model = new DeleteOrderItemCommand(orderid, productid);
        await _mediator.Send(model, cancellationToken);
        return Ok();
    }

    [HttpGet("{productid:guid}+{orderid:guid}")]
    public async Task<ActionResult> GetOrderItem(Guid orderid, Guid productid, CancellationToken cancellationToken)
    {
        GetOrderItemQuery query = new GetOrderItemQuery(orderid, productid);
        return Ok(await _mediator.Send(query, cancellationToken));
    }

    [HttpGet]
    public async Task<ActionResult> GetAllOrderItems([FromQuery] GetAllOrderItemsQuery query,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(query, cancellationToken));
    }
}


