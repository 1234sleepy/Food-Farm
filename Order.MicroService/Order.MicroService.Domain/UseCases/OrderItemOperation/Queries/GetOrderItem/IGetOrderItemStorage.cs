using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderItemOperation.Queries.GetOrderItem;

public interface IGetOrderItemStorage
{
    public Task<OrderItemModel> GetOrderItem(Guid orderId, Guid productId, CancellationToken cancellationToken);
}
