using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Order.MicroService.Domain.UseCases.OrderStatusOperation.Base;
using Order.MicroService.Domain.UseCases.OrderStatusOperation.Quries.GetAllOrderStatuses;

namespace Order.MicroService.Storage.Storages.OrderStatusOperatioin;

public class GetAllOrderStatusesStorage(DataContext dataContext, IMapper mapper) : IGetAllOrderStatusesStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public async Task<List<OrderStatusModel>> GetAllOrderStatuses(CancellationToken cancellationToken)
    {
        var res = await _dataContext.OrderStatuses.AsNoTracking().ProjectTo<OrderStatusModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        return res;
    }
}