using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using Domain.UseCases.AdminOperatation.OrderOperation.Command.UpdateOrder;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage.Storages.Admin.OrderOperation
{
    public class UpdateOrderStorage(DataContext dataContext, IMapper mapper) : IUpdateOrderStorage
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<OrderModel> UpdateOrder(Guid id, string name, string phone, DateTimeOffset createdAt, List<ItemModel> Items, Guid StatusId, CancellationToken cancellationToken)
        {
            Order nwOrder = await _dataContext.Orders.FirstAsync(p => p.Id == id, cancellationToken);

            decimal totalPrice = 0;
            decimal totalDiscount = 0;
            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (var item in Items)
            {
                Product product = await _dataContext.Products
                    .AsNoTracking()
                    .FirstAsync(p => p.Id == item.ProductId, cancellationToken);

                OrderItem orderItem = new OrderItem()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };

                totalPrice += item.Quantity * product.Price;

                totalDiscount += item.Quantity * product.DiscountPrice ?? 0;

                orderItems.Add(orderItem);
            }

            nwOrder.Name = name;
            nwOrder.Phone = phone;
            nwOrder.CreatedAt = createdAt;
            nwOrder.Items = orderItems;
            nwOrder.TotalPrice = totalPrice;
            nwOrder.TotalDiscount = totalDiscount;

            nwOrder.StatusId = StatusId;

            _dataContext.Orders.Update(nwOrder);
            await _dataContext.SaveChangesAsync(cancellationToken);

            var resOrder = await _dataContext.Orders
                .AsNoTracking()
                .ProjectTo<OrderModel>(_mapper.ConfigurationProvider)
                .FirstAsync(p => p.Id == id, cancellationToken);

            return resOrder;
        }
    }
}
