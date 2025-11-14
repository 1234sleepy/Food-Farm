using MediatR;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Command.SetlsMainImage;

public record class SetIsMainImageCommand(Guid imageId) : IRequest<ImageModel>
{
}
