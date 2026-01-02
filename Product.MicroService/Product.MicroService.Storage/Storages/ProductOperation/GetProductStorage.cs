using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProduct;

namespace Product.MicroService.Storage.Storages.ProductOperation;

public class GetProductStorage(DataContext dataContext, IMapper mapper) : IGetProductStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public async Task<ProductModel> GetProduct(Guid id, CancellationToken cancellationToken)
    {

        var product = await _dataContext.Products
            .AsNoTracking()
            .Include(x => x.ProductLabel!)
            .ThenInclude(pl => pl.Label)
            .ProjectTo<ProductModel>(_mapper.ConfigurationProvider)
            .FirstAsync(x => x.Id == id, cancellationToken);

        return product;
    }
}
