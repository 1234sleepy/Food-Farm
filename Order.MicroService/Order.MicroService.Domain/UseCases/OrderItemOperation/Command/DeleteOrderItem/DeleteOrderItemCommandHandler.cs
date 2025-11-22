using FluentValidation;
using MediatR;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Command.AddOrderItem;

namespace Order.MicroService.Domain.UseCases.OrderItemOperation.Command.DeleteOrderItem;

public class DeleteOrderItemCommandHandler(IDeleteOrderItemStorage deleteOrderItem, IValidator<DeleteOrderItemCommand> validator) : IRequestHandler<DeleteOrderItemCommand>
{
    private readonly IValidator<DeleteOrderItemCommand> _validator = validator;
    private readonly IDeleteOrderItemStorage _deleteOrderItem = deleteOrderItem;
    public async Task Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);
        await _deleteOrderItem.DeleteOrderItem(request.OrderId, request.ProductId, cancellationToken);
    }
}
