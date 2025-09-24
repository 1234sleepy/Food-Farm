using Domain.UseCases.Label.Base;
using MediatR;

namespace Domain.UseCases.Label.Command.AddLabelToProduct;

public record class AddLabelToProductCommand(string productId, string labelId) : IRequest
{
}
