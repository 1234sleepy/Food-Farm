using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.OrderOperation.Queries.GetOrder
{
    public interface IGetOrderStorage
    {
        public Task<OrderModel> GetOrder(Guid id, CancellationToken cancellationToken);
    }
}
