using AutoMapper;
using Domain.UseCases.OrderItemOperation.Base;
using Domain.UseCases.OrderItemOperation.Command.UpdateOrderItem;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Storages.OrderItemsOperation;

public class UpdateOrderItemStorage(DataContext dataContext, IMapper mapper) : IUpdateOrderItemStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public async Task<OrderItemModel> UpdateOrderItem(Guid orderId, Guid productId, int quantity, CancellationToken cancellationToken)
    {
        OrderItem nwOrderItem = _dataContext.OrderItems.First(x => x.OrderId == orderId && x.ProductId == productId);

        nwOrderItem.Quantity = quantity;

        _dataContext.OrderItems.Update(nwOrderItem);
        await _dataContext.SaveChangesAsync(cancellationToken);

        var resOrderItem = await _dataContext.OrderItems.
            FirstOrDefaultAsync(x => x.OrderId == orderId && x.ProductId == productId, cancellationToken);

        return _mapper.Map<OrderItemModel>(resOrderItem);
    }
}
