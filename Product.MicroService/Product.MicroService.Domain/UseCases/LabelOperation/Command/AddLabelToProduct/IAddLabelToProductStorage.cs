namespace Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabelToProduct;

public interface IAddLabelToProductStorage
{
    Task AddLabelToProductAsync(Guid productId, Guid labelId, CancellationToken cancellationToken);
}
