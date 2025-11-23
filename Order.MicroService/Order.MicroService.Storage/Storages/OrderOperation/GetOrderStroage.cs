using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Queries.GetOrder;

namespace Order.MicroService.Storage.Storages.OrderOperation;

public class GetOrderStorage(DataContext dataContext, IMapper mapper) : IGetOrderStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public async Task<OrderModel> GetOrder(Guid id, CancellationToken cancellationToken)
    {
        var order = await _dataContext.Orders.ProjectTo<OrderModel>(_mapper.ConfigurationProvider).FirstAsync(x => x.Id == id, cancellationToken);
        return order;
    }
}
