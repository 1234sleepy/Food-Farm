using Domain.UseCases.OrderStatusOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.OrderStatusOperation.Queries.GetAllOderStatuses
{
    public interface IGetAllOrderStatusesStorage
    {
        Task<List<OrderStatusModel>> GetAllOrderStatuses(CancellationToken cancellationToken);
    }
}
