
using Cart.MicroService.Domain.Entities;

namespace Cart.MicroService.Domain.UseCases.UpdateCartWolverine;

public record UpdateCartCommand(Guid UserId, Guid ProductId, int Quantity);

public class UpdateCartHandler(IUpdateCartStorage storage)
{
    private readonly IUpdateCartStorage _storage = storage;
    public async Task<CartEntity> Handle(UpdateCartCommand command, CancellationToken ct)
    {
        CartEntity cart = new CartEntity
        {
            UserId = command.UserId,
            ProductId = command.ProductId,
            Quantity = command.Quantity
        };
        return await _storage.UpdateCart(cart, ct);
    }
}