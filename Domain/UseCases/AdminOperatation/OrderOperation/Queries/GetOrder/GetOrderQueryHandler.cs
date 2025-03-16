using Domain.UseCases.AdminOperatation.AdminOrderOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.AdminOrderOperation.Queries.GetOrder
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
