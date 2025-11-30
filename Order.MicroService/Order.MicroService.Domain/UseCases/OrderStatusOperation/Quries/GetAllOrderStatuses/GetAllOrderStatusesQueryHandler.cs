using FluentValidation;
using MediatR;
using Order.MicroService.Domain.UseCases.OrderStatusOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderStatusOperation.Quries.GetAllOrderStatuses;

public class GetAllOrderStatusesQueryHandler(IGetAllOrderStatusesStorage getAllOrderStatuses) : IRequestHandler<GetAllOrderStatusesQuery, List<OrderStatusModel>>
{
    private readonly IGetAllOrderStatusesStorage _getAllOrderStatuses = getAllOrderStatuses;
    public Task<List<OrderStatusModel>> Handle(GetAllOrderStatusesQuery request, CancellationToken cancellationToken)
    {
        return _getAllOrderStatuses.GetAllOrderStatuses(cancellationToken);
    }
}