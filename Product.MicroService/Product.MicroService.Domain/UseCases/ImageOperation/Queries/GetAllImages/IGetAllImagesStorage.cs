using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetAllProducts;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Queries.GetAllImages;

public interface IGetAllImagesStorage
{
    public IQueryable<ImageModel> GetAllImages(GetAllImagesQuery query);
}
