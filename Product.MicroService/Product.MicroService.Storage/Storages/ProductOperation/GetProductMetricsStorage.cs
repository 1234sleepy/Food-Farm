using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProductMetricsQuery;
using Product.MicroService.Storage.Entities;

namespace Product.MicroService.Storage.Storages.ProductOperation;

public class GetProductMetricsStorage(DataContext dataContext, IMapper mapper) : IGetProductMetricsStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductMetricsModel> GetProductMetrics(Guid id, CancellationToken cancellationToken)
    {
        ProductE product = await _dataContext.Products.FirstAsync(x => x.Id == id, cancellationToken);
        ProductMetrics metrics = new ProductMetrics()
        {
            QuantityLimit = product.QuantityLimit,
            QuantitySold = product.QuantitySold,
            TotalCommentsQuantity = product.TotalCommentsQuantity,
            TotalRating = product.TotalRating
        };

        return _mapper.Map<ProductMetricsModel>(metrics);
    }
}
