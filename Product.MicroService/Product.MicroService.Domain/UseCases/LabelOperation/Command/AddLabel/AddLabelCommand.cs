using MediatR;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;

namespace Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabel;

public record class AddLabelCommand(string name, string color) : IRequest<LabelModel>
{
}
