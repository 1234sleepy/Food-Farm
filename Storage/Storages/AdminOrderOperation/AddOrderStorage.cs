using AutoMapper;
using Domain.UseCases.AdminOrderOperation.Base;
using Domain.UseCases.AdminOrderOperation.Command.AddOrder;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Storages.AdminOrderOperation
{
    public class AddOrderStorage(DataContext dataContext, IMapper mapper) : IAddOrderStorage
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<OrderModel> AddOrder(Guid id, string name, string phone, DateTimeOffset createdAt, List<Guid> itemsId, CancellationToken cancellationToken)
        {

            List<OrderItem> orderItems = new List<OrderItem>();

            if (itemsId.Count > 0)
            {
                foreach (var itemId in itemsId)
                {
                    OrderItem? orderItem = await _dataContext.OrderItems.FirstOrDefaultAsync(p => p.OrderId == itemId, cancellationToken);
                    if (orderItem != null)
                    {
                        orderItems.Add(orderItem);
                    }
                }
            }

            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Phone = phone,
                CreatedAt = createdAt,
                Items = orderItems
            };

            await _dataContext.Orders.AddAsync(order, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            var resOrder = await _dataContext.Orders
            .AsNoTracking()
            .SingleAsync(o => o.Id == order.Id, cancellationToken);

            return _mapper.Map<OrderModel>(resOrder);
        }
    }
}
