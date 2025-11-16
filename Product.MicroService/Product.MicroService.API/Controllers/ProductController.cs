using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.DeleteProduct;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateProduct;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetAllProducts;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProduct;

namespace Product.MicroService.API.Controllers;

[ApiController, Route("api/product")]
public class ProductController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

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

    [HttpPost()]
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
    public async Task<ActionResult> DeleteProduct(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteProductCommand(id), cancellationToken);
        return Ok();
    }
}
