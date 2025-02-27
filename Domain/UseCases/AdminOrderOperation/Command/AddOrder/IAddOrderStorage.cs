using Domain.UseCases.AdminOrderOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOrderOperation.Command.AddOrder
{
    public interface IAddOrderStorage
    {
        Task<OrderModel> AddOrder(Guid id, string name, string phone, DateTimeOffset createdAt, List<Guid> itemsId, CancellationToken cancellationToken);
    }
}
