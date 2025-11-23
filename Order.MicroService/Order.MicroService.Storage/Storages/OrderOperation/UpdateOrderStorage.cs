using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Command.UpdateOrder;
using Storage.Entities;

namespace Order.MicroService.Storage.Storages.OrderOperation;

public class UpdateOrderStorage(DataContext dataContext, IMapper mapper) : IUpdateOrderStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<OrderModel> UpdateOrder(Guid id, string name, string phone, List<ItemModel> Items, Guid StatusId, CancellationToken cancellationToken)
    {
        //DetailOrder nwOrder = await _dataContext.Orders.Include(x => x.Items)!.ThenInclude(x => x.Product).FirstAsync(p => p.Id == id, cancellationToken);

        //foreach (var item in Items)
        //{

        //    var isExist = nwOrder.Items!.FirstOrDefault(o => o.ProductId == item.ProductId && o.OrderId == id);

        //    if (isExist != null)
        //    {
        //        isExist.Quantity = item.Quantity;

        //        nwOrder.TotalPrice += item.Quantity * isExist.Product!.Price;

        //        nwOrder.TotalDiscount += item.Quantity * isExist.Product!.DiscountPrice ?? 0;

        //    }
        //    else
        //    {
        //        Product product = await _dataContext.Products
        //        .AsNoTracking()
        //        .FirstAsync(p => p.Id == item.ProductId, cancellationToken);

        //        OrderItem orderItem = new OrderItem()
        //        {
        //            ProductId = item.ProductId,
        //            Quantity = item.Quantity,
        //        };
        //        nwOrder.Items!.Add(orderItem);

        //        nwOrder.TotalPrice += item.Quantity * product.Price;

        //        nwOrder.TotalDiscount += item.Quantity * product.DiscountPrice ?? 0;
        //    }
        //}

        //nwOrder.Name = name;
        //nwOrder.Phone = phone;

        //nwOrder.StatusId = StatusId;


        //await _dataContext.SaveChangesAsync(cancellationToken);

        var resOrder = await _dataContext.Orders
            .AsNoTracking()
            .ProjectTo<OrderModel>(_mapper.ConfigurationProvider)
            .FirstAsync(p => p.Id == id, cancellationToken);

        return resOrder;
    }
}