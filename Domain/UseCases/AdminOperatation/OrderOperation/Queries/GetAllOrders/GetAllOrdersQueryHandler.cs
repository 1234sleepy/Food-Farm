using Domain.Extensions;
using Domain.Models;
using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.OrderOperation.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler(IGetAllOrdersStorage storage) : IRequestHandler<GetAllOrdersQuery, PaginationList<OrderModel>>
    {
        private readonly IGetAllOrdersStorage _storage = storage;
        public Task<PaginationList<OrderModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_storage.GetAllOrder(request).AsPagination(request));
        }
    }
}

