using FluentValidation;
using MediatR;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Queries.GetOrder;

public class GetOrderQueryHandler(IGetOrderStorage getOrderStorage) : IRequestHandler<GetOrderQuery, OrderModel>
{
    private readonly IGetOrderStorage _getOrderStorage = getOrderStorage;
    public async Task<OrderModel> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        return await _getOrderStorage.GetOrder(request.Id, cancellationToken);
    }
}

