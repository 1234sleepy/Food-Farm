using Domain.UseCases.AdminOperatation.AdminOrderOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.AdminOrderOperation.Queries.GetAllOrders
{
    public interface IGetAllOrdersStorage
    {
        public IQueryable<OrderModel> GetAllOrder(GetAllOrdersQuery query);
    }
}
