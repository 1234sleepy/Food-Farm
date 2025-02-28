using Domain.UseCases.OrderItemOperation.Base;

namespace Domain.UseCases.OrderItemOperation.Queries.GetOrderItem;

public interface IGetOrderItemStorage
{
    public Task<OrderItemModel> GetOrderItem(Guid orderId, Guid productId, CancellationToken cancellationToken);
}
