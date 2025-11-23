using Microsoft.EntityFrameworkCore;
using Order.MicroService.Domain.UseCases.OrderOperation.Command.DeleteOrder;

namespace Order.MicroService.Storage.Storages.OrderOperation;

public class DeleteOrderStorage(DataContext dataContext) : IDeleteOrderStorage
{
    private readonly DataContext _dataContext = dataContext;

    public async Task DeleteOrder(Guid Id, CancellationToken cancellationToken)
    {
        var order = await _dataContext.Orders.FirstAsync(p => p.Id == Id, cancellationToken);
        if (order != null)
        {
            _dataContext.Orders.Remove(order);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}