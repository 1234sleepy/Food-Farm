using Domain.UseCases.AdminOperatation.AdminOrderOperation.Command.UpdateOrder;
using Domain.UseCases.AdminOperatation.AdminOrderOperation.Queries.GetAllOrders;
using Domain.UseCases.AdminOperatation.AdminOrderOperation.Queries.GetOrder;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Command.AddProduct;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Command.UpdateProduct;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Queries.GetAllProducts;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Queries.GetProduct;
using Domain.UseCases.AdminOperatation.ImageOperation.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController, Route("api/admin")]
public class AdminController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;


    [HttpPost("product")]
    public async Task<ActionResult> AddProduct([FromBody] AddProductCommand model,
    CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(model, cancellationToken));
    }

    [HttpPut("product/{id:guid}")]
    public async Task<ActionResult> UpdateProduct(Guid id,
        [FromBody] UpdateProductCommand model,
        CancellationToken cancellationToken)
    {
        model.Id = id;
        return Ok(await _mediator.Send(model, cancellationToken));
    }

    [HttpDelete("product/{id:guid}")]
    public async Task<ActionResult> DeleteProduct(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(id, cancellationToken);
        return Ok();
    }

    [HttpGet("product/{id:guid}")]
    public async Task<ActionResult> GetProduct(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetProductQuery(id), cancellationToken));
    }

    [HttpGet("product")]
    public async Task<ActionResult> GetAllProducts([FromQuery] GetAllProductsQuery query,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(query, cancellationToken));
    }



    [HttpPut("order/{id:guid}")]
    public async Task<ActionResult> UpdateOrder(Guid id,
    [FromBody] UpdateOrderCommand model,
    CancellationToken cancellationToken)
    {
        model.Id = id;
        return Ok(await _mediator.Send(model, cancellationToken));
    }

    [HttpDelete("order/{id:guid}")]
    public async Task<ActionResult> DeleteOrder(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(id, cancellationToken);
        return Ok();
    }

    [HttpGet("order/{id:guid}")]
    public async Task<ActionResult> GetOrder(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetOrderQuery(id), cancellationToken));
    }

    [HttpGet("order")]
    public async Task<ActionResult> GetAllOrders([FromQuery] GetAllOrdersQuery query,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(query, cancellationToken));
    }

    [HttpPost("image/{productId:guid}")]
    public async Task<ActionResult> AddImage(Guid productId, IFormFile file,
        CancellationToken cancellationToken)
    {
        HttpContext.Request.Host = new HostString();
        return Ok(await _mediator.Send(new AddImageCommand(productId, file.FileName, file.OpenReadStream()), cancellationToken));
    }
}
