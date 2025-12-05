namespace Cart.MicroService.Domain.UseCases.ResetCart;

public interface IResetCartStorage
{
    public Task ResetCartCommand(Guid userId, CancellationToken cancellationToken);
}
