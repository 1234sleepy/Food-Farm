using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;
using Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabelToProduct;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;

namespace Product.MicroService.Storage.Storages.ProductOperation;

public class AddProductStorage(DataContext dataContext, IMapper mapper, IAddLabelToProductStorage addLabelToProductStorage) : IAddProductStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductEntity> AddProduct(ProductEntity product, CancellationToken cancellationToken)
    {
        product.CreatedAt = DateTimeOffset.UtcNow;

        await _dataContext.Products.AddAsync(product, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        var resProduct = await _dataContext.Products
        .AsNoTracking()
        .SingleAsync(p => p.Id == product.Id, cancellationToken);

        return resProduct;
    }
}
