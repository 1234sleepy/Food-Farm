using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using MediatR;

namespace Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;

public class GetOrderByPhoneQueryHandler(IGetOrderByPhoneStorage getOrderByPhoneStorage) : IRequestHandler<GetOrderByPhoneQuery,List<OrderModel>>
{
    private readonly IGetOrderByPhoneStorage _getOrderByPhoneStorage = getOrderByPhoneStorage;
    public async Task<List<OrderModel>> Handle(GetOrderByPhoneQuery request, CancellationToken cancellationToken)
    {
        return await _getOrderByPhoneStorage.GetOrderByPhone(request.Phone, cancellationToken);
    }
}

