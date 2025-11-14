namespace Product.MicroService.Domain.UseCases.LabelOperation.Command.RemoveLabelFromProduct;

public interface IRemoveLabelFromProductStorage
{
    Task RemoveLabelFromProduct(Guid productId, Guid labelId, CancellationToken cancellationToken);
}
