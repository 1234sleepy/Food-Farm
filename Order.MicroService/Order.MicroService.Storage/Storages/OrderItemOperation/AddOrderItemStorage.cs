using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Command.AddOrderItem;
using Storage.Entities;

namespace Order.MicroService.Storage.Storages.OrderItemOperation;

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


        var order = await _dataContext.Orders.FirstAsync(x => x.Id == orderId, cancellationToken);

        //var product = await _dataContext.Products.FirstAsync(x => x.Id == productId, cancellationToken);

        //product.QuantitySold++;

        //order.TotalPrice += product.Price * orderItem.Quantity;
        //order.TotalDiscount += product.DiscountPrice!.Value * orderItem.Quantity;


        await _dataContext.OrderItems.AddAsync(orderItem, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        var resOrderItem = await _dataContext.OrderItems.
            FirstOrDefaultAsync(x => x.OrderId == orderItem.OrderId && x.ProductId == orderItem.ProductId, cancellationToken);


        return _mapper.Map<OrderItemModel>(resOrderItem);
    }
}