using Product.MicroService.Domain.UseCases.LabelOperation.Base;

namespace Product.MicroService.Domain.UseCases.LabelOperation.Query.GetAllUsedLabelByProductId;

public interface IGetAllUsedLabelByProductIdStorage
{
    Task<List<LabelModel>> GetAllUsedLabels(Guid productId, CancellationToken cancellationToken);
}
