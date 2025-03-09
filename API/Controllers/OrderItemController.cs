//using Domain.UseCases.AdminOrderOperation.Command.DeleteOrder;
//using Domain.UseCases.OrderItemOperation.Command.AddOrderItem;
//using Domain.UseCases.OrderItemOperation.Command.DeleteOrderItem;
//using Domain.UseCases.OrderItemOperation.Command.UpdateOrderItem;
//using Domain.UseCases.OrderItemOperation.Queries.GetAllOrderItems;
//using Domain.UseCases.OrderItemOperation.Queries.GetOrderItem;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Storage.Entities;

//namespace API.Controllers;

//[ApiController, Route("api/order-item")]

//public class OrderItemController(IMediator mediator) : ControllerBase
//{
//    private readonly IMediator _mediator = mediator;

//    [HttpPost]
//    public async Task<ActionResult> AddOrderItem([FromBody] AddOrderItemCommand model,
//        CancellationToken cancellationToken)
//    {
//        return Ok(await _mediator.Send(model, cancellationToken));
//    }

//    [HttpPut()]
//    public async Task<ActionResult> UpdateOrderItem(
//        [FromBody] UpdateOrderItemCommand model,
//        CancellationToken cancellationToken)
//    {
//        return Ok(await _mediator.Send(model, cancellationToken));
//    }

//    [HttpDelete()]
//    public async Task<ActionResult> DeleteOrderItem(DeleteOrderItemCommand model, CancellationToken cancellationToken)
//    {
//        await _mediator.Send(model, cancellationToken);
//        return Ok();
//    }

//    [HttpGet("{productid:guid}+{orderid:guid}")]
//    public async Task<ActionResult> GetOrderItem(Guid orderid, Guid productid, CancellationToken cancellationToken)
//    {
//        GetOrderItemQuery query = new GetOrderItemQuery(orderid, productid);
//        return Ok(await _mediator.Send(query, cancellationToken));
//    }

//    [HttpGet]
//    public async Task<ActionResult> GetAllOrderItems([FromQuery] GetAllOrderItemsQuery query,
//        CancellationToken cancellationToken)
//    {
//        return Ok(await _mediator.Send(query, cancellationToken));
//    }
//}
