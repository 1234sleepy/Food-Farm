using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Queries.GetAllOrders;

namespace Order.MicroService.Storage.Storages.OrderOperation;

public class GetAllOrdersStorage(DataContext dataContext, IMapper mapper) : IGetAllOrdersStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public IQueryable<OrderModel> GetAllOrder(GetAllOrdersQuery query)
    {
        var take = _dataContext.Orders.AsNoTracking();

        take = query.Sort switch
        {
            "id" => take.OrderBy(x => x.Id),
            "name" => take.OrderBy(x => x.Name),
            "phone" => take.OrderBy(x => x.Phone),
            _ => take
        };

        return take.ProjectTo<OrderModel>(_mapper.ConfigurationProvider);
    }
}