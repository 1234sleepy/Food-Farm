namespace Cart.MicroService.Domain.UseCases.ResetCartWolverine;

public interface IResetCartStorage
{
    public Task ResetCart(Guid userId, CancellationToken cancellationToken);
}
