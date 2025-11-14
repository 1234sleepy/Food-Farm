using MediatR;

namespace Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabelToProduct;

public record class AddLabelToProductCommand(string productId, string labelId) : IRequest
{
}
