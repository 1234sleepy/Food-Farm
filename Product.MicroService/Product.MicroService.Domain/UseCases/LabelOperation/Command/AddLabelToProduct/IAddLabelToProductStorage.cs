namespace Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabelToProduct;

public interface IAddLabelToProductStorage
{
    Task AddLabelToProduct(Guid productId, Guid labelId, CancellationToken cancellationToken);
}
