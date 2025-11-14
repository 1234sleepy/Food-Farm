using MediatR;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Command.DeleteImage;

public record class DeleteImageCommand(Guid imageId) : IRequest
{
}
