using MediatR;

namespace Order.MicroService.Domain.UseCases.OrderItemOperation.Command.DeleteOrderItem;

public record class DeleteOrderItemCommand(Guid OrderId, Guid ProductId) : IRequest
{
}
