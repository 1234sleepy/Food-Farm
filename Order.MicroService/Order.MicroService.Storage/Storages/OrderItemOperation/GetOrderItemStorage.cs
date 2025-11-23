using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Queries.GetOrderItem;

namespace Order.MicroService.Storage.Storages.OrderItemOperation;

public class GetOrderItemStorage(DataContext dataContext, IMapper mapper) : IGetOrderItemStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public async Task<OrderItemModel> GetOrderItem(Guid orderId, Guid productId, CancellationToken cancellationToken)
    {
        var orderItem = await _dataContext.OrderItems.FirstAsync(x => x.OrderId == orderId && x.ProductId == productId, cancellationToken);

        return _mapper.Map<OrderItemModel>(orderItem);
    }
}
