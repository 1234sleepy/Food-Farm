
using Cart.MicroService.Domain.UseCases.Base;
using Cart.MicroService.Domain.UseCases.UpdateCartWolverine;
using Mapster;
using Microsoft.EntityFrameworkCore;


namespace Cart.MicroService.Storage.Storages;

public class UpdateCartStorage(DataContext dataContext) : IUpdateCartStorage
{
    private readonly DataContext _dataContext = dataContext;

    public async Task<CartModel> UpdateCart(Guid UserId, Guid ProductId, int Quantity, CancellationToken cancellationToken)
    {
       await _dataContext.Cart.Where(x => x.userId == UserId && x.productId == ProductId)
            .ExecuteUpdateAsync(p => p.SetProperty(x => x.quantity, Quantity), cancellationToken);

        return new CartModel { UserId = UserId, ProductId = ProductId, Quantity = Quantity};
    }
}
