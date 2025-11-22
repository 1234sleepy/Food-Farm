using FluentValidation;
using MediatR;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderItemOperation.Command.UpdateOrderItem;

public class UpdateOrderItemCommandHandler(
    IValidator<UpdateOrderItemCommand> validator,
    IUpdateOrderItemStorage updateOrderItemStorage) : IRequestHandler<UpdateOrderItemCommand, OrderItemModel>
{
    private readonly IValidator<UpdateOrderItemCommand> _validator = validator;
    private readonly IUpdateOrderItemStorage _updateOrderItemStorage = updateOrderItemStorage;

    public async Task<OrderItemModel> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);

        return await _updateOrderItemStorage.UpdateOrderItem(
                request.orderId,
                request.productId,
                request.quantity,
                cancellationToken);
    }
}
