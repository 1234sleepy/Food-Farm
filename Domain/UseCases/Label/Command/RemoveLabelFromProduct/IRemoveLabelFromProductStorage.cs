namespace Domain.UseCases.Label.Command.RemoveLabelFromProduct;

public interface IRemoveLabelFromProductStorage
{
    Task RemoveLabelFromProduct(Guid productId, Guid labelId, CancellationToken cancellationToken);
}
