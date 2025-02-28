using AutoMapper;
using Domain.UseCases.OrderItemOperation.Base;
using Domain.UseCases.OrderItemOperation.Command.AddOrderItem;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Storages.OrderItemsOperation;

public class AddOrderItemStorage(DataContext dataContext, IMapper mapper) : IAddOrderItemStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<OrderItemModel> AddOrderItem(Guid orderId, Guid productId, int quantity, CancellationToken cancellationToken)
    {
        OrderItem orderItem = new OrderItem()
        {
            OrderId = orderId,
            ProductId = productId,
            Quantity = quantity
        };

        await _dataContext.OrderItems.AddAsync(orderItem, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        var resOrderItem = await _dataContext.OrderItems.
            FirstOrDefaultAsync(x => x.OrderId == orderItem.OrderId && x.ProductId == orderItem.ProductId, cancellationToken);

        return _mapper.Map<OrderItemModel>(resOrderItem);
    }
}
