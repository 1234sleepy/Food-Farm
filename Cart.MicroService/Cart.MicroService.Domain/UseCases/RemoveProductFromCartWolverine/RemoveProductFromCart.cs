using Cart.MicroService.Domain.UseCases.ResetCartWolverine;

namespace Cart.MicroService.Domain.UseCases.RemoveProductFromCartWolverine;

public record RemoveProductFromCartCommand(Guid UserId, Guid ProductId);

public class ResetCartHandler(IRemoveProductFromCartStorage storage)
{
    private readonly IRemoveProductFromCartStorage _storage = storage;
    public async Task Handle(RemoveProductFromCartCommand command, CancellationToken ct)
    {
        await _storage.RemoveProductFromCart(command.UserId, command.ProductId, ct);
    }
}