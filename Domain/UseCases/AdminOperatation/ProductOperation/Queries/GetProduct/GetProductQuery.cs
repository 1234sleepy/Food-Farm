using Domain.Monitoring;
using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Queries.GetProduct;

public record class GetProductQuery(Guid Id) : IRequest<ProductModel>, IMonitoringRequest
{
    private const string COUNT_NAME = "get.product";
    public void MonitorSuccess(DomainMetrics metrics)
    {
        metrics.Increment(COUNT_NAME, 1);
    }
}
