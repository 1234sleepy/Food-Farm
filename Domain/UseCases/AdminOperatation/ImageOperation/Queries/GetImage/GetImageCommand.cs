using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Queries.GetImage;

public record class GetImageCommand(Guid imageId, CancellationToken cancellationToken) : IRequest<ImageModel>
{
}
