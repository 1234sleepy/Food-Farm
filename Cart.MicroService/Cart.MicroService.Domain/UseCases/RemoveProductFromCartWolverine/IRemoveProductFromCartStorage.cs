namespace Cart.MicroService.Domain.UseCases.RemoveProductFromCartWolverine;

public interface IRemoveProductFromCartStorage
{
    public Task RemoveProductFromCart(Guid userId, Guid productId, CancellationToken cancellationToken);
}
