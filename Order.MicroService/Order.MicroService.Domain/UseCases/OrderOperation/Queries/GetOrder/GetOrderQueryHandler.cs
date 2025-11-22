using FluentValidation;
using MediatR;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Queries.GetOrder;

public class GetOrderQueryHandler(IGetOrderStorage getOrderStorage, IValidator<GetOrderQuery> validor) : IRequestHandler<GetOrderQuery, OrderModel>
{
    private readonly IValidator<GetOrderQuery> _validator = validor;
    private readonly IGetOrderStorage _getOrderStorage = getOrderStorage;
    public async Task<OrderModel> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);
        return await _getOrderStorage.GetOrder(request.Id, cancellationToken);
    }
}

