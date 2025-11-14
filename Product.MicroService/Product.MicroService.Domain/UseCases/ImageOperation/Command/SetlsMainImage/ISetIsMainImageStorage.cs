using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Command.SetlsMainImage;

public interface ISetIsMainImageStorage
{
    Task<ImageModel> SetIsMainImage(Guid imageId, CancellationToken cancellationToken);

    Task<bool> IsImageExists(Guid imageId, CancellationToken cancellationToken);
}
