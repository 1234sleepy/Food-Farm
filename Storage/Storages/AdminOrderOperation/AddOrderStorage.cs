using AutoMapper;
using Domain.UseCases.AdminOrderOperation.Base;
using Domain.UseCases.AdminOrderOperation.Command.AddOrder;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Storages.AdminOrderOperation
{
    public class AddOrderStorage(DataContext dataContext, IMapper mapper) : IAddOrderStorage
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<OrderModel> AddOrder(Guid id, string name, int phone, DateTimeOffset createdAt, List<OrderItemModel> Items, CancellationToken cancellationToken)
        {
            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Phone = phone.ToString(),
                CreatedAt = createdAt,
                Items = Items.Select(item => new OrderItem{}).ToList()
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
