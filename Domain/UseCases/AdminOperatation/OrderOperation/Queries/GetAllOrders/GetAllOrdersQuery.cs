using Domain.Models;
using Domain.Monitoring;
using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using Domain.UseCases.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.OrderOperation.Queries.GetAllOrders
{
    public record class GetAllOrdersQuery(string? Sort) : PaginationQuery, IRequest<PaginationList<OrderModel>>, IMonitoringRequest
    {
        private const string COUNT_NAME = "get.all.orders";
        public void MonitorSuccess(DomainMetrics metrics)
        {
            metrics.Increment(COUNT_NAME, 1);
        }
    }
}
