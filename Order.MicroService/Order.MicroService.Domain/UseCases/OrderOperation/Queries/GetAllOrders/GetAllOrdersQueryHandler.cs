using FluentValidation;
using MediatR;
using Order.MicroService.Domain.Extensions;
using Order.MicroService.Domain.UseCases.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Queries.GetAllOrders;

public class GetAllOrdersQueryHandler(IGetAllOrdersStorage storage, IValidator<GetAllOrdersQuery> validator) : IRequestHandler<GetAllOrdersQuery, PaginationList<OrderModel>>
{
    private readonly IValidator<GetAllOrdersQuery> _validator = validator;
    private readonly IGetAllOrdersStorage _storage = storage;
    public Task<PaginationList<OrderModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        _validator.ValidateAsync(request, cancellationToken);
        return Task.FromResult(_storage.GetAllOrder(request).AsPagination(request));
    }
}
