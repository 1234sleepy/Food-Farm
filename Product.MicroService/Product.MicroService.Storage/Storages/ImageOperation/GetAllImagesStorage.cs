using AutoMapper;
using AutoMapper.QueryableExtensions;
using Product.MicroService.Domain.UseCases.ImageOperation.Queries.GetAllImages;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetAllProducts;

namespace Product.MicroService.Storage.Storages.ImageOperation;

public class GetAllImagesStorage(DataContext dataContext, IMapper mapper) : IGetAllImagesStorage
{
    private readonly DataContext dataContext = dataContext;
    private readonly IMapper mapper = mapper;

    public IQueryable<ImageModel> GetAllImages(GetAllImagesQuery query)
    {
        var take = dataContext.Images.AsQueryable();

        take = query.Sort switch
        {
            "id" => take = take.OrderBy(x => x.Id),
            "name" => take = take.OrderBy(x => x.Name),
            _ => take
        };

        return take.ProjectTo<ImageModel>(mapper.ConfigurationProvider);
    }
}
