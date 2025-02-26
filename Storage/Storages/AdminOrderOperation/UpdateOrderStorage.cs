using AutoMapper;
using Domain.UseCases.AdminOrderOperation.Base;
using Domain.UseCases.AdminOrderOperation.Command.UpdateOrder;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<OrderModel> UpdateOrder(Guid id, string name, int phone, DateTimeOffset createdAt, List<OrderItemModel> Items, CancellationToken cancellationToken)
        {
            Order nwOrder = await _dataContext.Orders.FirstAsync(p => p.Id == id, cancellationToken);

            nwOrder.Id = id;
            nwOrder.Name = name;
            nwOrder.Phone = phone.ToString();
            nwOrder.CreatedAt = createdAt;
            nwOrder.Items = _mapper.Map<List<OrderItem>>(Items);

            _dataContext.Orders.Update(nwOrder);
            await _dataContext.SaveChangesAsync(cancellationToken);

            var resOrder = await _dataContext.Orders
                .AsNoTracking()
                .SingleAsync(p => p.Id == id, cancellationToken);

            return _mapper.Map<OrderModel>(resOrder);
        }
    }
}
