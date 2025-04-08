using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.OrderOperation.Command.UpdateOrder
{
    public interface IUpdateOrderStorage
    {
        public Task<OrderModel> UpdateOrder(Guid id, string name, string phone, DateTimeOffset createdAt, List<Guid> itemsId, CancellationToken cancellationToken);
    }
}
