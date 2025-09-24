using Domain.UseCases.Label.Base;

namespace Domain.UseCases.Label.Command.AddLabel;

public interface IAddLabelStorage
{
    Task<LabelModel> AddLabel(string name, string color, CancellationToken cancellationToken);
}
