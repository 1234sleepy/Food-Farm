using Domain.Extensions;
using Domain.Models;
using Domain.UseCases.AdminOrderOperation.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOrderOperation.Queries.GetAllOrder
{
    public class AddAllOrderQueryHandler(IGetAllOrderStorage storage) : IRequestHandler<AddAllOrderQuery, PaginationList<OrderModel>>
    {
        private readonly IGetAllOrderStorage _storage = storage;
        public Task<PaginationList<OrderModel>> Handle(AddAllOrderQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_storage.GetAllOrder(request).AsPagination(request));
        }
    }
}

