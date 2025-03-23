using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Command.SetIsMainImage;

public record class SetIsMainImageCommand(Guid imageId, CancellationToken CancellationToken) : IRequest<ImageModel>
{
}
