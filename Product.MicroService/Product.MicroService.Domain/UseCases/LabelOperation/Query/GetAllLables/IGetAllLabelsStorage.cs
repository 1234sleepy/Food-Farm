using Product.MicroService.Domain.UseCases.LabelOperation.Base;

namespace Product.MicroService.Domain.UseCases.LabelOperation.Query.GetAllLables;

public interface IGetAllLabelsStorage
{
    Task<List<LabelModel>> GetAllLabels(CancellationToken cancellationToken);
}
