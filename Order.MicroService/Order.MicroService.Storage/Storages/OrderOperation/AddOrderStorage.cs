using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Command.AddOrder;
using Storage.Entities;

namespace Order.MicroService.Storage.Storages.OrderOperation;

public class AddOrderStorage(DataContext dataContext, IMapper mapper) : IAddOrderStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<OrderModel> AddOrder(OrderModel orderModel, CancellationToken cancellationToken)
    {

        DetailOrder order = new DetailOrder()
        {
            Name = orderModel.Name,
            Phone = orderModel.Phone,
            Description = orderModel.Description,
            CreatedAt = DateTimeOffset.UtcNow,
            Email = orderModel.Email
        };

        await _dataContext.Orders.AddAsync(order, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        var resOrder = await _dataContext.Orders
        .AsNoTracking()
        .ProjectTo<OrderModel>(_mapper.ConfigurationProvider)
        .SingleAsync(o => o.Id == order.Id, cancellationToken);

        return resOrder;
    }
}