using Domain.Models;
using Domain.Monitoring;
using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using Domain.UseCases.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Queries.GetAllProducts;

public record class GetAllProductsQuery(string? Sort) : PaginationQuery, IRequest<PaginationList<ProductModel>>, IMonitoringRequest
{
    private const string COUNT_NAME = "get.all.products";
    public void MonitorSuccess(DomainMetrics metrics)
    {
        metrics.Increment(COUNT_NAME, 1);
    }
}
