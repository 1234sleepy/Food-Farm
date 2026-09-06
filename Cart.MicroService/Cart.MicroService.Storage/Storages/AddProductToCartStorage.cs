using Cart.MicroService.Domain.Entities;
using Cart.MicroService.Domain.UseCases.AddProductToCartWolverine;
using Cart.MicroService.Domain.UseCases.Base;
using Cart.MicroService.Domain.UseCases.UpdateCartWolverine;

using Mapster;

namespace Cart.MicroService.Storage.Storages;

public class AddProductToCartStorage(DataContext dataContext) : IAddProductToCartStorage
{
    private readonly DataContext _dataContext = dataContext;

    public async Task<CartEntity> AddProductToCart(CartEntity cart, CancellationToken cancellationToken)
    {

        await _dataContext.Cart.AddAsync(cart, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return cart;
    }

}
