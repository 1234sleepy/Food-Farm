using FluentValidation;
using MediatR;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderItemOperation.Command.AddOrderItem;

public class AddOrderItemCommandHandler(IAddOrderItemStorage orderItemStorage) : IRequestHandler<AddOrderItemCommand, OrderItemModel>
{
    private readonly IAddOrderItemStorage _orderItemStorage = orderItemStorage;

    public async Task<OrderItemModel> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
    {
        return await _orderItemStorage.AddOrderItem(
            request.orderId,
            request.productId,
            request.quantity,
            cancellationToken);
    }
}
