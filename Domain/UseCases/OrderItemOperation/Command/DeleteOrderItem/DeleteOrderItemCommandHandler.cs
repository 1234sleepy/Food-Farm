using MediatR;

namespace Domain.UseCases.OrderItemOperation.Command.DeleteOrderItem;

public class DeleteOrderItemCommandHandler(IDeleteOrderItemStorage deleteOrderItem) : IRequestHandler<DeleteOrderItemCommand>
{
    private readonly IDeleteOrderItemStorage _deleteOrderItem = deleteOrderItem;
    public async Task Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
    {
        await _deleteOrderItem.DeleteOrderItem(request.OrderId, request.ProductId, cancellationToken);
    }
}
