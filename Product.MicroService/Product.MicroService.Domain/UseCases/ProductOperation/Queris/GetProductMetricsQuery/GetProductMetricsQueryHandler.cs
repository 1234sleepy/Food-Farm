using MediatR;
using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProduct;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProductMetricsQuery;

public class GetProductMetricsQueryHandler(IGetProductMetricsStorage getProductMetricsStorage) : IRequestHandler<GetProductMetricsQuery, ProductMetricsEntity>
{
    private readonly IGetProductMetricsStorage _getProductMetricsStorage = getProductMetricsStorage;

    public async Task<ProductMetricsEntity> Handle(GetProductMetricsQuery request, CancellationToken cancellationToken)
    {
        return await _getProductMetricsStorage.GetProductMetrics(request.Id, cancellationToken);
    }
}
