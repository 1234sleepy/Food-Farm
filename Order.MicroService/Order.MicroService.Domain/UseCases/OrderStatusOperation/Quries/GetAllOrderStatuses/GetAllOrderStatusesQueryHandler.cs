using FluentValidation;
using MediatR;
using Order.MicroService.Domain.UseCases.OrderStatusOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderStatusOperation.Quries.GetAllOrderStatuses;

public class GetAllOrderStatusesQueryHandler(IGetAllOrderStatusesStorage getAllOrderStatuses, IValidator<GetAllOrderStatusesQuery> validator) : IRequestHandler<GetAllOrderStatusesQuery, List<OrderStatusModel>>
{
    private readonly IValidator<GetAllOrderStatusesQuery> _validator = validator;
    private readonly IGetAllOrderStatusesStorage _getAllOrderStatuses = getAllOrderStatuses;
    public Task<List<OrderStatusModel>> Handle(GetAllOrderStatusesQuery request, CancellationToken cancellationToken)
    {
        _validator.ValidateAsync(request, cancellationToken);
        return _getAllOrderStatuses.GetAllOrderStatuses(cancellationToken);
    }
}