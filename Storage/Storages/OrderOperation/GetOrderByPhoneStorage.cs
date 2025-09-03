using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;

namespace Storage.Storages.OrderOperation;

public class GetOrderByPhoneStorage(DataContext dataContext, IMapper mapper) : IGetOrderByPhoneStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public IQueryable<OrderModel> GetOrderByPhone(string phone, CancellationToken cancellationToken)
    {
        var take = _dataContext.Orders.Select(x => x.Phone == phone);

        return take.ProjectTo<OrderModel>(_mapper.ConfigurationProvider);
    }
}

