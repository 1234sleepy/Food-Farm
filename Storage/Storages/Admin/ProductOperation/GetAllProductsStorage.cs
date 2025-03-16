using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Queries.GetAllProducts;
using Microsoft.EntityFrameworkCore;

namespace Storage.Storages.Admin.AdminProductOperation;

public class GetAllProductsStorage(DataContext dataContext, IMapper mapper) : IGetAllProductsStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public IQueryable<ProductModel> GetAllProducts(GetAllProductsQuery query)
    {
        var take = _dataContext.Products.AsNoTracking();

        take = query.Sort switch
        {
            "id" => take.OrderBy(x => x.Id),
            "name" => take.OrderBy(x => x.Name),
            "price" => take.OrderBy(x => x.Price),
            _ => take
        };

        return take.ProjectTo<ProductModel>(_mapper.ConfigurationProvider);
    }
}
