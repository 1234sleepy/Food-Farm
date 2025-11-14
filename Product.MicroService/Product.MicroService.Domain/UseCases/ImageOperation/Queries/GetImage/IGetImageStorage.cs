using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Queries.GetImage;

public interface IGetImageStorage
{
    Task<ImageModel> GetImage(Guid id, CancellationToken cancellationToken);

    Task<bool> IsImageExists(Guid imageId, CancellationToken cancellationToken);
}
