using Domain.UseCases.AdminOrderOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOrderOperation.Queries.GetOrder
{
    public interface IGetOrderStorage
    {
        public Task<OrderModel> GetOrder(Guid id, CancellationToken cancellationToken);
    }
}
