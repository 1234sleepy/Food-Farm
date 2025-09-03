using Domain.UseCases.Label.Base;

namespace Domain.UseCases.Label.Command.AddLabelToProduct;

public interface IAddLabelToProductStorage
{
    Task<ProductLabelModel> AddLabelToProductAsync(Guid productId, Guid labelId, CancellationToken cancellationToken);
}
