using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabel;
using Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabelToProduct;
using Product.MicroService.Domain.UseCases.LabelOperation.Command.RemoveLabelFromProduct;
using Product.MicroService.Domain.UseCases.LabelOperation.Query.GetAllLables;
using Product.MicroService.Domain.UseCases.LabelOperation.Query.GetAllUsedLabelByProductId;

namespace Product.MicroService.API.Controllers;

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
    public async Task<ActionResult> GetAllUsedLabelByProductId([FromQuery] GetAllUsedLabelByProductIdQuery query,
CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(query, cancellationToken));
    }

    [HttpDelete("remove-label-from-product/{productid:guid}+{labelid:guid}")]
    public async Task RemoveLabelFromProduct(Guid productid, Guid labelid, CancellationToken cancellationToken)
    {
        RemoveLabelFromProductCommand model = new RemoveLabelFromProductCommand(productid, labelid);
        await _mediator.Send(model, cancellationToken);
    }
}
