using FluentValidation;
using MediatR;
using Order.MicroService.Domain.Extensions;
using Order.MicroService.Domain.UseCases.Base;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderItemOperation.Queries.GetAllOrderItems;

public class GetAllOrderItemsQueryHandler(IGetAllOrderItemsStorage storage, IValidator<GetAllOrderItemsQuery> validator) : IRequestHandler<GetAllOrderItemsQuery, PaginationList<OrderItemModel>>
{
    private readonly IValidator<GetAllOrderItemsQuery> _validator = validator;
    private readonly IGetAllOrderItemsStorage _storage = storage;
    public Task<PaginationList<OrderItemModel>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
    {
         _validator.ValidateAsync(request, cancellationToken);
        return Task.FromResult(_storage.GetAllOrderItems(request).AsPagination(request));
    }
}
