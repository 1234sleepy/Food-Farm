using MediatR;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderItemOperation.Command.UpdateOrderItem;

public record class UpdateOrderItemCommand(Guid orderId, Guid productId, int quantity) : IRequest<OrderItemModel>
{
}
