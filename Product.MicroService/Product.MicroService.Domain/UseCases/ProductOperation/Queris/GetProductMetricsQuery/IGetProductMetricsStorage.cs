using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProductMetricsQuery;

public interface IGetProductMetricsStorage
{
    public Task<ProductMetricsModel> GetProductMetrics(Guid id, CancellationToken cancellationToken);
}
