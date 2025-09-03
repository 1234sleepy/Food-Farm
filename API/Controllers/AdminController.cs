using API.Dtos;
using Domain.UseCases.AdminOperatation.ImageOperation.Command.AddImage;
using Domain.UseCases.AdminOperatation.ImageOperation.Command.DeleteImage;
using Domain.UseCases.AdminOperatation.ImageOperation.Command.SetIsMainImage;
using Domain.UseCases.AdminOperatation.OrderOperation.Command.DeleteOrder;
using Domain.UseCases.AdminOperatation.OrderOperation.Command.UpdateOrder;
using Domain.UseCases.AdminOperatation.OrderOperation.Queries.GetAllOrders;
using Domain.UseCases.AdminOperatation.OrderOperation.Queries.GetOrder;
using Domain.UseCases.AdminOperatation.ProductOperation.Command.AddProduct;
using Domain.UseCases.AdminOperatation.ProductOperation.Command.DeleteProduct;
using Domain.UseCases.AdminOperatation.ProductOperation.Command.UpdateCharacteristic;
using Domain.UseCases.AdminOperatation.ProductOperation.Command.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController, Route("api/admin"), Authorize]
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
        await _mediator.Send(new DeleteProductCommand(id), cancellationToken);
        return Ok();
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
        await _mediator.Send(new DeleteOrderCommand(id), cancellationToken);
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
    public async Task<ActionResult> AddImage([FromRoute]Guid productId, IFormFile file,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new AddImageCommand(productId, file.FileName, file.OpenReadStream()), cancellationToken));
    }
#if DEBUG
    [HttpGet("image/{productId:guid}")]
    public async Task<ActionResult> GetImage(Guid productId,
    CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(productId, cancellationToken));
    }
#endif
    [HttpPut("image/set-is-main-image/{imageId:guid}")]
    public async Task<ActionResult> setIsMain(Guid imageId, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new SetIsMainImageCommand(imageId), cancellationToken));
    }

    [HttpDelete("image/{imageId:Guid}")]
    public async Task<ActionResult> DeleteImage(Guid imageId, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteImageCommand(imageId), cancellationToken);
        return Ok();
    }

    [HttpPost("product/updateCharacteristic/{id:Guid}")]
    public async Task<ActionResult> UpdateCharacteristic(Guid id,
        [FromBody] CharacteristicUpdateDto dto,
        CancellationToken cancellationToken)
    {
        var model = new UpdateCharacteristicCommand(id, dto.JSON);
        await _mediator.Send(model, cancellationToken);
        return Ok();
    }
}
