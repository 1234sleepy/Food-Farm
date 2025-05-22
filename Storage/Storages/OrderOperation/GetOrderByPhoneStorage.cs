using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models;
using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using Domain.UseCases.OrderItemOperation.Base;
using Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Storage.Storages.OrderOperation;

public class GetOrderByPhoneStorage(DataContext dataaContext, IMapper mapper) : IGetOrderByPhoneStorage
{
    private readonly DataContext _dataContext = dataaContext;
    private readonly IMapper _mapper = mapper;

    public IQueryable<OrderModel> GetOrderByPhone(string phone, CancellationToken cancellationToken)
    {
        var take = _dataContext.Orders.Select(x => x.Phone == phone);
        
        return take.ProjectTo<OrderModel>(_mapper.ConfigurationProvider);
    }
}

