using Domain.UseCases.OrderItemOperation.Base;
using MediatR;

namespace Domain.UseCases.OrderItemOperation.Command.UpdateOrderItem;

public record class UpdateOrderItemCommand(Guid orderId, Guid productId, int quantity) : IRequest<OrderItemModel>
{
}
