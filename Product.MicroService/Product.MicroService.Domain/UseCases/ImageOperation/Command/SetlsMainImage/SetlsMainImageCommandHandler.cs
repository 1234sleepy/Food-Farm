using MediatR;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Command.SetlsMainImage;

public class SetlsMainImageCommandHandler(ISetIsMainImageStorage setIsMainImageStorage) : IRequestHandler<SetIsMainImageCommand, ImageModel>
{
    private readonly ISetIsMainImageStorage _setIsMainImageStorage = setIsMainImageStorage;
    public async Task<ImageModel> Handle(SetIsMainImageCommand request, CancellationToken cancellationToken)
    {
        return await _setIsMainImageStorage.SetIsMainImage(request.imageId, cancellationToken);
    }
}
