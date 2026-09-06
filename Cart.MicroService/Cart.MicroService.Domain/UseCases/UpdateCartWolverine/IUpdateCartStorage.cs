using Cart.MicroService.Domain.Entities;
using Cart.MicroService.Domain.UseCases.Base;

namespace Cart.MicroService.Domain.UseCases.UpdateCartWolverine;

public interface IUpdateCartStorage
{
    Task<CartEntity> UpdateCart(CartEntity cart, CancellationToken cancellationToken);
}
