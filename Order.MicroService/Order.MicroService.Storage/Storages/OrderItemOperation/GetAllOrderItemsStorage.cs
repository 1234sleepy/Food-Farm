using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Queries.GetAllOrderItems;

namespace Order.MicroService.Storage.Storages.OrderItemOperation;

public class GetAllOrderItemsStorage(DataContext dataContext, IMapper mapper) : IGetAllOrderItemsStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public IQueryable<OrderItemModel> GetAllOrderItems(GetAllOrderItemsQuery query)
    {
        var take = _dataContext.OrderItems.AsNoTracking();
        take = query.Sort switch
        {
            "productId" => take.OrderBy(x => x.ProductId),
            "orderId" => take.OrderBy(x => x.OrderId),
            _ => take
        };
        return take.ProjectTo<OrderItemModel>(_mapper.ConfigurationProvider);
    }
}
