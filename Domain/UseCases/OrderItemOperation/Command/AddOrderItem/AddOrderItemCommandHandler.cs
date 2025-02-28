using Domain.UseCases.OrderItemOperation.Base;
using FluentValidation;
using MediatR;

namespace Domain.UseCases.OrderItemOperation.Command.AddOrderItem;

public class AddOrderItemCommandHandler(IAddOrderItemStorage orderItemStorage,
    IValidator<AddOrderItemCommand> validator) : IRequestHandler<AddOrderItemCommand, OrderItemModel>
{
    private readonly IValidator<AddOrderItemCommand> _validator = validator;
    private readonly IAddOrderItemStorage _orderItemStorage = orderItemStorage;

    public async Task<OrderItemModel> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        return await _orderItemStorage.AddOrderItem(
            request.orderId,
            request.productId,
            request.quantity,
            cancellationToken);
    }
}
