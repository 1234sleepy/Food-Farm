using AutoMapper;
using Domain.UseCases.OrderItemOperation.Base;
using Domain.UseCases.OrderItemOperation.Queries.GetOrderItem;
using Microsoft.EntityFrameworkCore;

namespace Storage.Storages.OrderItemsOperation;

public class GetOrderItemStorage(DataContext dataContext, IMapper mapper) : IGetOrderItemStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public  async Task<OrderItemModel> GetOrderItem(Guid orderId, Guid productId, CancellationToken cancellationToken)
    {
        var orderItem = await _dataContext.OrderItems.FirstAsync(x => x.OrderId == orderId && x.ProductId == productId, cancellationToken);
    
        return _mapper.Map<OrderItemModel>(orderItem);
    }
}
