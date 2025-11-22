using FluentValidation;
using MediatR;
using Order.MicroService.Domain.Extensions;
using Order.MicroService.Domain.UseCases.Base;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Queries.GetOrderItem;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;

public class GetOrderByPhoneQueryHandler(IGetOrderByPhoneStorage getOrderByPhoneStorage, IValidator<GetOrderByPhoneQuery> validator) : IRequestHandler<GetOrderByPhoneQuery, PaginationList<OrderModel>>
{
    private readonly IValidator<GetOrderByPhoneQuery> _validator = validator;
    private readonly IGetOrderByPhoneStorage _getOrderByPhoneStorage = getOrderByPhoneStorage;

    public Task<PaginationList<OrderModel>> Handle(GetOrderByPhoneQuery request, CancellationToken cancellationToken)
    {
        _validator.ValidateAsync(request, cancellationToken);
        return Task.FromResult(_getOrderByPhoneStorage.GetOrderByPhone(request.Phone, cancellationToken).AsPagination(request));
    }
}

