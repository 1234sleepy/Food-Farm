using Domain.UseCases.Base;
using Domain.UseCases.OrderStatusOperation.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.OrderStatusOperation.Queries.GetAllOderStatuses
{
    public record class GetAllOrderStatusesQuery() : IRequest<List<OrderStatusModel>>
    {
    }

}
