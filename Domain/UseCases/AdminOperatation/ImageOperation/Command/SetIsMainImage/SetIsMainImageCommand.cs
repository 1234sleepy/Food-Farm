using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Command.SetIsMainImage;

public record class SetIsMainImageCommand(Guid imageId, CancellationToken CancellationToken) : IRequest<ImageModel>
{
}
