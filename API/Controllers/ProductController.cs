using Domain.UseCases.AdminOperatation.ProductOperation.Queries.GetAllProducts;
using Domain.UseCases.AdminOperatation.ProductOperation.Queries.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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
}
