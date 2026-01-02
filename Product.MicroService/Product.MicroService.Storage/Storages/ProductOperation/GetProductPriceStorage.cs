using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProductPriceQuery;
using Product.MicroService.Storage.Entities;

namespace Product.MicroService.Storage.Storages.ProductOperation;

public class GetProductPriceStorage(DataContext dataContext) : IGetProductPriceStorage
{
    private readonly DataContext _dataContext = dataContext;

    public async Task<decimal> GetPrice(Guid id, CancellationToken cancellationToken)
    {
        ProductE product = await _dataContext.Products.FirstAsync(x => x.Id == id, cancellationToken);

        return product.Price;
    }
}
