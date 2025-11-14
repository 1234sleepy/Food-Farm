using MediatR;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Command.AddImage;

public record class AddImageCommand(Guid productId, string fileName, Stream Stream) : IRequest<ImageModel>
{
}
