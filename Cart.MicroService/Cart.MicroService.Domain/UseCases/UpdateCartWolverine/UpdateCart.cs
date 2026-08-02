
using Cart.MicroService.Domain.UseCases.CreateCart;

namespace Cart.MicroService.Domain.UseCases.UpdateCartWolverine;

public record UpdateCartCommand(Guid UserId, Guid ProductId, int Quantity);

public class ResetCartHandler(IUpdateCartStorage storage)
{
    private IUpdateCartStorage _storage = storage;
    public async Task Handle(UpdateCartCommand command, CancellationToken ct)
    {
        await _storage.UpdateCart(command.UserId,command.ProductId,command.Quantity, ct);
    }
}