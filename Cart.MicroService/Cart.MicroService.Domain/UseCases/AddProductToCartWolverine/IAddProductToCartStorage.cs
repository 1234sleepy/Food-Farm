using Cart.MicroService.Domain.Entities;
using Cart.MicroService.Domain.UseCases.Base;

namespace Cart.MicroService.Domain.UseCases.AddProductToCartWolverine;

public interface IAddProductToCartStorage
{
    public Task<CartEntity> AddProductToCart(CartEntity cart, CancellationToken cancellationToken);
}
