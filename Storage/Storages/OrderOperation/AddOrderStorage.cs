using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using Domain.UseCases.OrderOperation.Command.AddOrder;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage.Storages.OrderOperation;

public class AddOrderStorage(DataContext dataContext, IMapper mapper) : IAddOrderStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<OrderModel> AddOrder(string name, string phone, List<ItemModel> items, string? description, string? email, CancellationToken cancellationToken)
    {
        decimal totalPrice = 0;
        decimal totalDiscount = 0;
        List<OrderItem> orderItems = new List<OrderItem>();

        foreach (var item in items)
        {
            Console.WriteLine(item);
            Console.WriteLine(item.ProductId);
            Product product = await _dataContext.Products
                .AsNoTracking()
                .FirstAsync(p => p.Id == item.ProductId, cancellationToken);

            OrderItem orderItem = new OrderItem()
            {
                ProductId = item.ProductId
            };

            product.QuantitySold++;

            orderItem.Quantity = item.Quantity>product.QuantityLimit?product.QuantityLimit:item.Quantity;

            totalPrice += item.Quantity * product.Price;

            totalDiscount += item.Quantity * product.DiscountPrice ?? 0;

            orderItems.Add(orderItem);
        }

        Order order = new Order()
        {
            Name = name,
            Phone = phone,
            Description = description,
            CreatedAt = DateTimeOffset.UtcNow,
            Items = orderItems,
            TotalPrice = totalPrice,
            TotalDiscount = totalDiscount,
            Email = email
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
