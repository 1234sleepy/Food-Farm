using MediatR;

namespace Domain.UseCases.OrderItemOperation.Command.DeleteOrderItem;

public record class DeleteOrderItemCommand(Guid OrderId, Guid ProductId) : IRequest
{
}
