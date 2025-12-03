namespace Cart.MicroService.Domain.UseCases.ResetCart;

public interface IResetCartCommand
{
    public Task ResetCartCommand(Guid userId, CancellationToken cancellationToken);
}
