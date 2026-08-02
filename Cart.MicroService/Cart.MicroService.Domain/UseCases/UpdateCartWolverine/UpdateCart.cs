
using Cart.MicroService.Domain.UseCases.Base;
using Cart.MicroService.Domain.UseCases.UpdateCart;

namespace Cart.MicroService.Domain.UseCases.UpdateCartWolverine;

public record UpdateCartCommand(Guid UserId, Guid ProductId, int Quantity);

public class UpdateCartHandler(IUpdateCartStorage storage)
{
    private readonly IUpdateCartStorage _storage = storage;
    public async Task<CartModel> Handle(UpdateCartCommand command, CancellationToken ct)
    {
        return await _storage.UpdateCart(command.UserId,command.ProductId,command.Quantity, ct);
    }
}