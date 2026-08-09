using Cart.MicroService.Domain.UseCases.Base;
using Cart.MicroService.Domain.UseCases.ResetCartWolverine;

namespace Cart.MicroService.Domain.UseCases.AddProductToCartWolverine;

public record AddProductToCartCommand(Guid UserId, Guid ProductId, int Quantity);

public class AddProductToCartHandler(IAddProductToCartStorage storage)
{
    private readonly IAddProductToCartStorage _storage = storage;
    public async Task Handle(AddProductToCartCommand command, CancellationToken ct)
    {
        await _storage.AddProductToCart(command.UserId, command.ProductId, command.Quantity, ct);
    }
}