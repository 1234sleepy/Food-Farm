using Cart.MicroService.Domain.UseCases.Base;

namespace Cart.MicroService.Domain.UseCases.UpdateCartWolverine;

public interface IUpdateCartStorage
{
    Task<CartModel> UpdateCart(Guid UserId, Guid ProductId, int Quantity, CancellationToken cancellationToken);
}
