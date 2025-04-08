using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using Domain.UseCases.AdminOperatation.ProductOperation.Queries.GetProduct;
using Microsoft.EntityFrameworkCore;

namespace Storage.Storages.Admin.ProductOperation;

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
