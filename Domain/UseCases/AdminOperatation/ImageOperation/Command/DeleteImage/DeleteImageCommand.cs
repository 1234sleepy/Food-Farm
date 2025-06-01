using MediatR;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Command.DeleteImage;

public record class DeleteImageCommand(Guid imageId) : IRequest
{
}
