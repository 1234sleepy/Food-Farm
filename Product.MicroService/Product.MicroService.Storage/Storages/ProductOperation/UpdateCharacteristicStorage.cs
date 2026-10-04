using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateProduct;

namespace Product.MicroService.Storage.Storages.ProductOperation;

public class UpdateProductStorage(DataContext dataContext, IMapper mapper) : IUpdateProductStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductEntity> UpdateProduct(ProductEntity product, CancellationToken cancellationToken)
    {
        ProductEntity nwProduct = await _dataContext.Products.FirstAsync(p => p.Id == product.Id, cancellationToken);

        nwProduct.Name = product.Name;
        nwProduct.Price = product.Price;
        nwProduct.Description = product.Description;
        nwProduct.IsVisible = product.IsVisible;
        nwProduct.QuantityLimit = product.QuantityLimit;
        nwProduct.DiscountPrice = product.DiscountPrice;


        _dataContext.Products.Update(nwProduct);
        await _dataContext.SaveChangesAsync(cancellationToken);

        var resProd = await _dataContext.Products
            .AsNoTracking()
            .SingleAsync(p => p.Id == product.Id, cancellationToken);

        return resProd;
    }

}
