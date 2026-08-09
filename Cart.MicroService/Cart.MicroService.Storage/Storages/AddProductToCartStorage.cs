using Cart.MicroService.Domain.UseCases.AddProductToCartWolverine;
using Cart.MicroService.Domain.UseCases.Base;
using Cart.MicroService.Domain.UseCases.UpdateCartWolverine;
using Cart.MicroService.Storage.Entities;
using Mapster;

namespace Cart.MicroService.Storage.Storages;

public class AddProductToCartStorage(DataContext dataContext) : IAddProductToCartStorage
{
    private readonly DataContext _dataContext = dataContext;

    public async Task<CartModel> AddProductToCart(Guid userId, Guid productId, int quantity, CancellationToken cancellationToken)
    {
        CartEntity cart = new()
        {
            userId = userId,
            productId = productId,
            quantity = quantity
        };
        await _dataContext.Cart.AddAsync(cart, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return cart.Adapt<CartModel>();
    }

}
