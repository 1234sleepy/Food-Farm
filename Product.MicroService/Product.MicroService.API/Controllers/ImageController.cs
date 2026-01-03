
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.MicroService.Domain.UseCases.ImageOperation.Command.AddImage;
using Product.MicroService.Domain.UseCases.ImageOperation.Command.DeleteImage;
using Product.MicroService.Domain.UseCases.ImageOperation.Command.SetlsMainImage;
using Product.MicroService.Domain.UseCases.ImageOperation.Queries.GetAllImages;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetAllProducts;

namespace Product.MicroService.API.Controllers;

[ApiController, Route("api/image"),]
public class ImageController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("{productId:guid}")]
    public async Task<ActionResult> AddImage([FromRoute] Guid productId, IFormFile file,
    CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new AddImageCommand(productId, file.FileName, file.OpenReadStream()), cancellationToken));
    }

    [HttpGet("{productId:guid}")]
    public async Task<ActionResult> GetImage(Guid productId,
    CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(productId, cancellationToken));
    }

    [HttpGet("")]
    public async Task<ActionResult> GetAllImages([FromQuery] GetAllImagesQuery query, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(cancellationToken));
    }

    [HttpPut("set-is-main-image/{imageId:guid}")]
    public async Task<ActionResult> setIsMain(Guid imageId, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new SetIsMainImageCommand(imageId), cancellationToken));
    }

    [HttpDelete("{imageId:Guid}")]
    public async Task<ActionResult> DeleteImage(Guid imageId, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteImageCommand(imageId), cancellationToken);
        return Ok();
    }
}
