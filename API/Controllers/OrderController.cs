using Domain.UseCases.OrderOperation.Command.AddOrder;
using Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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
    [HttpGet("{phone}")]
    public async Task<ActionResult> GetOrderByPhone(string phone, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetOrderByPhoneQuery(phone), cancellationToken));
    }
}
