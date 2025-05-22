using Domain.UseCases.OrderStatusOperation.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.OrderStatusOperation.Queries.GetAllOderStatuses
{
    public class GetAllOrderStatusesQueryHandler(IGetAllOrderStatusesStorage getAllOrderStatuses) : IRequestHandler<GetAllOrderStatusesQuery, List<OrderStatusModel>>
    {
        private readonly IGetAllOrderStatusesStorage _getAllOrderStatuses = getAllOrderStatuses;
        public Task<List<OrderStatusModel>> Handle(GetAllOrderStatusesQuery request, CancellationToken cancellationToken)
        {
            return _getAllOrderStatuses.GetAllOrderStatuses(cancellationToken);
        }
    }

}
