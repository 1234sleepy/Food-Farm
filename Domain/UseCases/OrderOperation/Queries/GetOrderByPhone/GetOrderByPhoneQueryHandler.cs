using Domain.Extensions;
using Domain.Models;
using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using MediatR;

namespace Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;

public class GetOrderByPhoneQueryHandler(IGetOrderByPhoneStorage getOrderByPhoneStorage) : IRequestHandler<GetOrderByPhoneQuery, PaginationList<OrderModel>>
{
    private readonly IGetOrderByPhoneStorage _getOrderByPhoneStorage = getOrderByPhoneStorage;

    public Task<PaginationList<OrderModel>> Handle(GetOrderByPhoneQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_getOrderByPhoneStorage.GetOrderByPhone(request.Phone, cancellationToken).AsPagination(request));
    }
}

