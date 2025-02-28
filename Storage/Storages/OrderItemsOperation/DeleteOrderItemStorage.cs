using Domain.UseCases.OrderItemOperation.Command.DeleteOrderItem;
using Microsoft.EntityFrameworkCore;

namespace Storage.Storages.OrderItemsOperation;

public class DeleteOrderItemStorage(DataContext dataContext) : IDeleteOrderItemStorage
{
    private readonly DataContext _dataContext = dataContext;
    public async Task DeleteOrderItem(Guid OrderId, Guid ProductId, CancellationToken cancellationToken)
    {
        var order = await _dataContext.OrderItems.FirstAsync(p => p.OrderId == OrderId && p.ProductId == ProductId, cancellationToken);
        if (order != null)
        {
            _dataContext.OrderItems.Remove(order);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
