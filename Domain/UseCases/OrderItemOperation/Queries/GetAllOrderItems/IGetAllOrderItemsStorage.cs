using Domain.UseCases.OrderItemOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.OrderItemOperation.Queries.GetAllOrderItems
{
    public interface IGetAllOrderItemsStorage
    {
        public IQueryable<OrderItemModel> GetAllOrderItems(GetAllOrderItemsQuery query);
    }
}
