
using Cart.MicroService.Domain.Entities;
using Cart.MicroService.Domain.UseCases.Base;
using Cart.MicroService.Domain.UseCases.UpdateCartWolverine;
using Mapster;
using Microsoft.EntityFrameworkCore;


namespace Cart.MicroService.Storage.Storages;

public class UpdateCartStorage(DataContext dataContext) : IUpdateCartStorage
{
    private readonly DataContext _dataContext = dataContext;

    public async Task<CartEntity> UpdateCart(CartEntity cart, CancellationToken cancellationToken)
    {
       await _dataContext.Cart.Where(x => x.UserId == cart.UserId && x.ProductId == cart.ProductId)
            .ExecuteUpdateAsync(p => p.SetProperty(x => x.Quantity, cart.Quantity), cancellationToken);

        return cart;
    }
}
