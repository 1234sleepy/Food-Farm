using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Command.AddOrder;

public interface IAddOrderStorage
{
    Task<OrderModel> AddOrder(OrderModel orderModel, CancellationToken cancellationToken);
}

