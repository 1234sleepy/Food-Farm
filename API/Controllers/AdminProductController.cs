using Domain.UseCases.AdminProductOperation.Command.AddProduct;
using Domain.UseCases.AdminProductOperation.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Storage.Entities;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace API.Controllers;

[ApiController, Route("api/admin/product")]
public class AdminProductController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult> AddProduct([FromBody] AddProductCommand query,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(query, cancellationToken));
    }

    [HttpPut("{id:guid}")]
    public ActionResult UpdateProduct(Guid id, [FromQuery] Product query)
    {
        return Ok("Order");
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteProduct(Guid id)
    {
        return Ok("Order");
    }

    [HttpGet("{id:guid}")]
    public ActionResult GetProduct(Guid id)
    {
        return Ok("Order");
    }

    [HttpGet]
    public async Task<ActionResult> GetAllProducts([FromQuery] GetAllProductsQuery query,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(query, cancellationToken));
    }
}
