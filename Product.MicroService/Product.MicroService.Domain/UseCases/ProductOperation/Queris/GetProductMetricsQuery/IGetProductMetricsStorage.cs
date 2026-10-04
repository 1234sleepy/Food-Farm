using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProductMetricsQuery;

public interface IGetProductMetricsStorage
{
    public Task<ProductMetricsEntity> GetProductMetrics(Guid id, CancellationToken cancellationToken);
}
