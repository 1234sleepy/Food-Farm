using Domain.Monitoring;
using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.OrderOperation.Queries.GetOrder;

public record class GetOrderQuery(Guid Id) : IRequest<OrderModel>, IMonitoringRequest
{
    private const string COUNT_NAME = "get.order";
    public void MonitorSuccess(DomainMetrics metrics)
    {
        metrics.Increment(COUNT_NAME, 1);
    }
}