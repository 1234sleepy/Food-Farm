using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.AdminOrderOperation.Base;
using Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Storage.Storages.OrderOperation;

public class GetOrderByPhoneStorage(DataContext dataaContext, IMapper mapper) : IGetOrderByPhoneStorage
{
    private readonly DataContext _dataContext = dataaContext;
    private readonly IMapper _mapper = mapper;
    public async Task<List<OrderModel>> GetOrderByPhone(string phone, CancellationToken cancellationToken)
    {
        var order = await _dataContext.Orders
            .Where(x => x.Phone == phone)
            .OrderByDescending(x => x.CreatedAt)
            .ProjectTo<OrderModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return order;
    }
}

