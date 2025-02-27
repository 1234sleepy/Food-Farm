using Domain.UseCases.AdminOrderOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOrderOperation.Queries.GetAllOrder
{
    public interface IGetAllOrdersStorage
    {
        public IQueryable<OrderModel> GetAllOrder(GetAllOrdersQuery query);
    }
}
