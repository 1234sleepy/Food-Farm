using FluentValidation;
using MediatR;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderItemOperation.Queries.GetOrderItem;

public class GetOrderItemQueryHandler(IGetOrderItemStorage getOrderItemStorage, IValidator<GetOrderItemQuery> validator) : IRequestHandler<GetOrderItemQuery, OrderItemModel>
{
    private readonly IValidator<GetOrderItemQuery> _validator = validator;
    private readonly IGetOrderItemStorage _getOrderItemStorage = getOrderItemStorage;
    public async Task<OrderItemModel> Handle(GetOrderItemQuery request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);
        return await _getOrderItemStorage.GetOrderItem(request.orderId, request.productId, cancellationToken);
    }
}
