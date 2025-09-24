using Domain.UseCases.AdminOperatation.ProductOperation.Command.AddProduct;
using Domain.UseCases.Label.Command.AddLabel;
using Domain.UseCases.Label.Command.AddLabelToProduct;
using Domain.UseCases.Label.Query.GetAllLabels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController, Route("api/label")]
public class LabelController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost()]
    public async Task<ActionResult> AddLabel([FromBody] AddLabelCommand model,
    CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(model, cancellationToken));
    }
    [HttpPost("add-label-to-product")]
    public async Task AddLabelToProduct([FromBody] AddLabelToProductCommand model,
CancellationToken cancellationToken)
    {
        await _mediator.Send(model, cancellationToken);
    }

    [HttpGet("all")]
    public async Task<ActionResult> GetAllLabel([FromQuery] GetAllLabelsQuery query,
CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(query, cancellationToken));
    }

    [HttpGet("usedLabel")]
    public async Task<ActionResult> GetAllUsedLabelByProductId([FromQuery] GetAllLabelsQuery query,
CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(query, cancellationToken));
    }
}
