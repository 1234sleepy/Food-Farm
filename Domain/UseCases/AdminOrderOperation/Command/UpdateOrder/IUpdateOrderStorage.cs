using Domain.UseCases.AdminOrderOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOrderOperation.Command.UpdateOrder
{
    public interface IUpdateOrderStorage
    {
        public Task<OrderModel> UpdateOrder(Guid id, string name, int phone, DateTimeOffset createdAt, List<OrderItemModel> Items, CancellationToken cancellationToken);
    }
}
