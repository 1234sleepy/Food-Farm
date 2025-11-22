using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderItemOperation.Command.AddOrderItem;

public interface IAddOrderItemStorage
{
    Task<OrderItemModel> AddOrderItem(
    Guid orderId, Guid productId, int quantity, CancellationToken cancellationToken);
}
