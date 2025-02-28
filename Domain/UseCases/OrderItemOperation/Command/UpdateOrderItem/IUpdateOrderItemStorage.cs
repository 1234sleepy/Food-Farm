using Domain.UseCases.OrderItemOperation.Base;

namespace Domain.UseCases.OrderItemOperation.Command.UpdateOrderItem;

public interface IUpdateOrderItemStorage
{
    public Task<OrderItemModel> UpdateOrderItem(Guid orderId, Guid productId, int quantity, CancellationToken cancellationToken);
}
