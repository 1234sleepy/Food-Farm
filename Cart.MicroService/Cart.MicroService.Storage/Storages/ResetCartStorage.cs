using AutoMapper;
using Cart.MicroService.Domain.UseCases.ResetCartWolverine;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Cart.MicroService.Storage.Storages;

public class ResetCartStorage(DataContext dataContext) : IResetCartStorage
{
    private readonly DataContext _dataContext = dataContext;

    public async Task ResetCart(Guid userId, CancellationToken cancellationToken)
    {
       await _dataContext.Cart.Where(x => x.userId == userId).ExecuteDeleteAsync(cancellationToken);
    }
}
