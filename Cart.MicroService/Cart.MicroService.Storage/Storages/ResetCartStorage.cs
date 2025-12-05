using AutoMapper;
using Cart.MicroService.Domain.UseCases.ResetCart;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Cart.MicroService.Storage.Storages;

public class ResetCartStorage(DataContext dataContext) : IResetCartStorage
{
    private readonly DataContext _dataContext = dataContext;

    public async Task ResetCartCommand(Guid userId, CancellationToken cancellationToken)
    {
        var cart = _dataContext.Cart.AsNoTracking().Where(x => x.userId == userId);

        if (cart != null)
        {
            _dataContext.Cart.RemoveRange(cart);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }

    }
}
