using Product.MicroService.Domain.UseCases.LabelOperation.Base;

namespace Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabel;

public interface IAddLabelStorage
{
    Task<LabelModel> AddLabel(string name, string color, CancellationToken cancellationToken);
    Task<Guid> GetId(string name, CancellationToken cancellationToken);
    Task<bool> IsExist(string name, string color, CancellationToken cancellationToken);
}
