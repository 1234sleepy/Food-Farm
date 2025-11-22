using MediatR;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderItemOperation.Command.AddOrderItem;

public record class AddOrderItemCommand(Guid orderId, Guid productId, int quantity) : IRequest<OrderItemModel>
{
}
