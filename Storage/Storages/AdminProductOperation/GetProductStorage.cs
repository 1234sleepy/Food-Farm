using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.AdminOrderOperation.Base;
using Domain.UseCases.AdminProductOperation.Base;
using Domain.UseCases.AdminProductOperation.Queries.GetProduct;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage.Storages.AdminProductOperation;

public class GetProductStorage(DataContext dataContext, IMapper mapper) : IGetProductStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public async Task<ProductModel> GetProduct(Guid id, CancellationToken cancellationToken)
    {
        var product = await _dataContext.Products.ProjectTo<ProductModel>(_mapper.ConfigurationProvider).FirstAsync(x => x.Id == id, cancellationToken);

        return product;
    }
}
