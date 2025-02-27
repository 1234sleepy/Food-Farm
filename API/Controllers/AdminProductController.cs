using Domain.UseCases.AdminProductOperation.Command.AddProduct;
using Domain.UseCases.AdminProductOperation.Command.DeleteProduct;
using Domain.UseCases.AdminProductOperation.Command.UpdateProduct;
using Domain.UseCases.AdminProductOperation.Queries.GetAllProducts;
using Domain.UseCases.AdminProductOperation.Queries.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController, Route("api/admin/product")]
public class AdminProductController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult> AddProduct([FromBody] AddProductCommand model,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(model, cancellationToken));
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateProduct(Guid id,
        [FromBody] UpdateProductCommand model,
        CancellationToken cancellationToken)
    {
        model.Id = id;
        return Ok(await _mediator.Send(model, cancellationToken));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteProduct(DeleteProductCommand id, CancellationToken cancellationToken)
    {
        await _mediator.Send(id, cancellationToken);
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetProduct(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetProductQuery(id), cancellationToken));
    }

    [HttpGet]
    public async Task<ActionResult> GetAllProducts([FromQuery] GetAllProductsQuery query,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(query, cancellationToken));
    }
}
