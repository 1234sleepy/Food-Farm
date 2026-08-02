namespace Cart.MicroService.Domain.UseCases.ResetCart;

public interface IResetCartStorage
{
    public Task ResetCart(Guid userId, CancellationToken cancellationToken);
}
