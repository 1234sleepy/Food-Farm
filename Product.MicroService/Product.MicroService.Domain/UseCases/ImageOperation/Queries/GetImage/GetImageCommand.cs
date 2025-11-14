using MediatR;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Queries.GetImage;

public record class GetImageCommand(Guid imageId, CancellationToken cancellationToken) : IRequest<ImageModel>
{
}
