using MediatR;

namespace Domain.UseCases.Label.Command.RemoveLabelFromProduct;

public record class RemoveLabelFromProductCommand(Guid productId, Guid labelId) : IRequest
{

}
