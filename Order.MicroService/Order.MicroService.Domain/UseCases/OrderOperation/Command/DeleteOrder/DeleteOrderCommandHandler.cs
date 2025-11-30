using FluentValidation;
using MediatR;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Command.DeleteOrder;

public class DeleteOrderCommandHandler(IDeleteOrderStorage deleteOrder) : IRequestHandler<DeleteOrderCommand>
{
    private readonly IDeleteOrderStorage _deleteOrder = deleteOrder;
    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        await _deleteOrder.DeleteOrder(request.id, cancellationToken);
    }
}
