using Cart.MicroService.Domain.UseCases.Base;
using Cart.MicroService.Domain.UseCases.GetCartWolverine;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Cart.MicroService.Storage.Storages;

public class GetCartStorage(DataContext dataContext) : IGetCartStorage
{
    private readonly DataContext _dataContext = dataContext;

    public async Task<List<CartModel>> GetCart(Guid userId, CancellationToken cancellationToken)
    {
        var cartModels = await _dataContext.Cart.Where(x => x.userId == userId).AsNoTracking().ToListAsync(cancellationToken);

        return cartModels.Adapt<List<CartModel>>();
    }

}