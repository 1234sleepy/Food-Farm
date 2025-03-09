using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.AdminOrderOperation.Base;
using Domain.UseCases.AdminOrderOperation.Command.UpdateOrder;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Storage.Storages.AdminOrderOperation
{
    public class UpdateOrderStorage : IUpdateOrderStorage
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public UpdateOrderStorage(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<OrderModel> UpdateOrder(Guid id, string name, string phone, DateTimeOffset createdAt, List<Guid> itemsId, CancellationToken cancellationToken)
        {
            Order nwOrder = await _dataContext.Orders.FirstAsync(p => p.Id == id, cancellationToken);

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

            nwOrder.Id = id;
            nwOrder.Name = name;
            nwOrder.Phone = phone;
            nwOrder.CreatedAt = createdAt;
            nwOrder.Items = orderItems;

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
