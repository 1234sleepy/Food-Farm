using MediatR;

namespace Product.MicroService.Domain.UseCases.LabelOperation.Command.RemoveLabelFromProduct;

public record class RemoveLabelFromProductCommand(Guid productId, Guid labelId) : IRequest
{
}
