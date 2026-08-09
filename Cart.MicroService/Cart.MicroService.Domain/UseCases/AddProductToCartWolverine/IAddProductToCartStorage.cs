using Cart.MicroService.Domain.UseCases.Base;

namespace Cart.MicroService.Domain.UseCases.AddProductToCartWolverine;

public interface IAddProductToCartStorage
{
    public Task<CartModel> AddProductToCart(Guid userId, Guid productId, int quantity, CancellationToken cancellationToken);
}
