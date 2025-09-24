using Domain.UseCases.Label.Base;
using MediatR;

namespace Domain.UseCases.Label.Command.AddLabel;

public record class AddLabelCommand(string name, string color) : IRequest<LabelModel>
{
}
