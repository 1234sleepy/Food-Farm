using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetAllProducts;

namespace Product.MicroService.Storage.Storages.ProductOperation;

public class GetAllProductsStorage(DataContext dataContext, IMapper mapper) : IGetAllProductsStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public IQueryable<ProductModel> GetAllProducts(GetAllProductsQuery query)
    {
        var take = _dataContext.Products.AsNoTracking().Include(x => x.ProductLabel)!.ThenInclude(x => x.Label).AsQueryable();

        take = query.Sort switch
        {
            "id" => take.OrderBy(x => x.Id),
            "name" => take.OrderBy(x => x.Name),
            "price" => take.OrderBy(x => x.Price),
            "label" => take.OrderBy(x => x.ProductLabel!.OrderBy(y => y.Label!.Name).First()),
            _ => take
        };

        take = take.Where(x => x.Price >= query.minPrice && (x.Price <= query.MaxPrice || query.MaxPrice == 0));

        var test = take.ToList();
        return take.ProjectTo<ProductModel>(_mapper.ConfigurationProvider);
    }
}

