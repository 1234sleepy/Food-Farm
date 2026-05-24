using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Command.UpdateOrder;

public interface IUpdateOrderStorage
{
    public Task<OrderModel> UpdateOrder(Guid id, List<OrderItemModel> items, decimal totalPrice, decimal totalDiscount, CancellationToken cancellationToken);
}
