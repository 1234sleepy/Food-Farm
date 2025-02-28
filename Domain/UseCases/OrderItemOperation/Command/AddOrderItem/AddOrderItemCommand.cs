using Domain.UseCases.OrderItemOperation.Base;
using MediatR;

namespace Domain.UseCases.OrderItemOperation.Command.AddOrderItem;

public record class AddOrderItemCommand(Guid orderId, Guid productId, int quantity, CancellationToken cancellationToken) : IRequest<OrderItemModel>
{
}
