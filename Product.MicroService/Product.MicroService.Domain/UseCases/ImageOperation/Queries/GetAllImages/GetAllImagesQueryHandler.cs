using MediatR;
using Product.MicroService.Domain.UseCases.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Queries.GetAllImages;

public class GetAllImagesQueryHandler(IGetAllImagesStorage storage) : IRequestHandler<GetAllImagesQuery, PaginationList<ImageModel>>
{
    private readonly IGetAllImagesStorage _storage = storage;
    public Task<PaginationList<ImageModel>> Handle(GetAllImagesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_storage.GetAllImages(request).AsPagination(request));
    }
{
}
