using MediatR;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Queries.GetImage;

public class GetImageCommandHandler(IGetImageStorage getImageStorage) : IRequestHandler<GetImageCommand, ImageModel>
{
    public async Task<ImageModel> Handle(GetImageCommand request, CancellationToken cancellationToken)
    {
        return await getImageStorage.GetImage(request.imageId, request.cancellationToken);
    }
}
