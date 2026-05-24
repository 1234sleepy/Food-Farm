using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Command.UpdateOrder;
using Storage.Entities;

namespace Order.MicroService.Storage.Storages.OrderOperation;

public class UpdateOrderStorage(DataContext dataContext, IMapper mapper) : IUpdateOrderStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<OrderModel> UpdateOrder(Guid id, List<OrderItemModel> items, decimal totalPrice, decimal totalDiscount, CancellationToken cancellationToken)
    {
        await _dataContext.Orders.Where(x => x.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(x => x.TotalPrice, totalPrice)
                .SetProperty(x => x.TotalDiscount, totalDiscount), cancellationToken);

        foreach (var item in items) 
        {
            OrderItem ordItem = _mapper.Map<OrderItem>(item);
            ordItem.OrderId = id;

            await _dataContext.OrderItems.AddAsync(ordItem, cancellationToken);
        }

        var resOrder = await _dataContext.Orders
            .AsNoTracking()
            .ProjectTo<OrderModel>(_mapper.ConfigurationProvider)
            .FirstAsync(p => p.Id == id, cancellationToken);

        return resOrder;
    }
}