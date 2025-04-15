using Domain.UseCases.OrderItemOperation.Command.DeleteOrderItem;
using Microsoft.EntityFrameworkCore;

namespace Storage.Storages.OrderItemsOperation;

public class DeleteOrderItemStorage(DataContext dataContext) : IDeleteOrderItemStorage
{
    private readonly DataContext _dataContext = dataContext;
    public async Task DeleteOrderItem(Guid OrderId, Guid ProductId, CancellationToken cancellationToken)
    {
        var orderItem = await _dataContext.OrderItems.FirstAsync(p => p.OrderId == OrderId && p.ProductId == ProductId, cancellationToken);

        var order = await _dataContext.Orders.FirstAsync(x => x.Id == OrderId, cancellationToken);

        var product = await _dataContext.Products.FirstAsync(x => x.Id == ProductId, cancellationToken);

        if (orderItem != null && order!=null && product != null)
        {
            _dataContext.OrderItems.Remove(orderItem);


            order.TotalPrice -= product.Price * orderItem.Quantity;
            order.TotalDiscount -= product.DiscountPrice.Value * orderItem.Quantity;

            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
