using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProductMetricsQuery;

namespace Product.MicroService.Storage.Storages.ProductOperation;

public class GetProductMetricsStorage(DataContext dataContext, IMapper mapper) : IGetProductMetricsStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductMetricsEntity> GetProductMetrics(Guid id, CancellationToken cancellationToken)
    {
        ProductEntity product = await _dataContext.Products.FirstAsync(x => x.Id == id, cancellationToken);
        ProductMetricsEntity metrics = new ProductMetricsEntity()
        {
            QuantityLimit = product.QuantityLimit,
            QuantitySold = product.QuantitySold,
            TotalCommentsQuantity = product.TotalCommentsQuantity,
            TotalRating = product.TotalRating
        };

        return metrics;
    }
}
