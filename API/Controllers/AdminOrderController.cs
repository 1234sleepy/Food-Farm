using Domain.UseCases.AdminOrderOperation.Command.AddOrder;
using Domain.UseCases.AdminOrderOperation.Command.DeleteOrder;
using Domain.UseCases.AdminOrderOperation.Command.UpdateOrder;
using Domain.UseCases.AdminOrderOperation.Queries.GetAllOrder;
using Domain.UseCases.AdminOrderOperation.Queries.GetOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Storage.Entities;
using Storage.Storages.AdminOrderOperation;

namespace API.Controllers;

[ApiController, Route("api/admin/order")]
public class AdminOrderController(IMediator mediator) : ControllerBase
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
        await _mediator.Send(id, cancellationToken);
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetOrder(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetOrderQuery(id), cancellationToken));
    }

    [HttpGet]
    public async Task<ActionResult> GetAllOrders([FromQuery] GetAllOrdersQuery query,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(query, cancellationToken));
    }

}
