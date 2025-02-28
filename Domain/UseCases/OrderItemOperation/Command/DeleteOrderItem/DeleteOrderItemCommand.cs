using MediatR;

namespace Domain.UseCases.OrderItemOperation.Command.DeleteOrderItem;

public class DeleteOrderItemCommand : IRequest
{
    public required Guid OrderId { get; set; }
    public required Guid ProductId { get; set; }
}
