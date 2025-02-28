using Domain.Extensions;
using Domain.Models;
using Domain.UseCases.OrderItemOperation.Base;
using MediatR;

namespace Domain.UseCases.OrderItemOperation.Queries.GetAllOrderItems;

public class GetAllOrderItemsQueryHandler(IGetAllOrderItemsStorage storage) : IRequestHandler<GetAllOrderItemsQuery, PaginationList<OrderItemModel>>
{
    private readonly IGetAllOrderItemsStorage _storage = storage;
    public Task<PaginationList<OrderItemModel>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_storage.GetAllOrderItems(request).AsPagination(request));
    }
}
