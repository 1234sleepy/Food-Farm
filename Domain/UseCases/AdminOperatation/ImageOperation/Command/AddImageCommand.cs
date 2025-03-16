using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Command;

public record class AddImageCommand(Guid productId, string fileName, Stream Stream) : IRequest<ImageModel>
{
}
