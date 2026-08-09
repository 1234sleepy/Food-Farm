using Cart.MicroService.Domain.UseCases.RemoveProductFromCartWolverine;
using Cart.MicroService.Domain.UseCases.ResetCartWolverine;
using Microsoft.EntityFrameworkCore;

namespace Cart.MicroService.Storage.Storages;

public class RemoveProductFromCartStorage(DataContext dataContext) : IRemoveProductFromCartStorage
{
    private readonly DataContext _dataContext = dataContext;

    public async Task RemoveProductFromCart(Guid userId, Guid productId, CancellationToken cancellationToken)
    {
        await _dataContext.Cart.Where(x => x.userId == userId && x.productId == productId).ExecuteDeleteAsync(cancellationToken);
    }
}
