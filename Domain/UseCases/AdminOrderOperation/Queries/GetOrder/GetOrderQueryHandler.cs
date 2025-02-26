using Domain.UseCases.AdminOrderOperation.Base;
using Domain.UseCases.AdminProductOperation.Queries.GetProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOrderOperation.Queries.GetOrder
{
    public class GetOrderQueryHandler(IGetOrderStorage getOrderStorage) : IRequestHandler<GetOrderQuery, OrderModel>
    {
        private readonly IGetOrderStorage _getOrderStorage = getOrderStorage;
        public async Task<OrderModel> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            return await _getOrderStorage.GetOrder(request.Id, cancellationToken);
        }
    }
}
