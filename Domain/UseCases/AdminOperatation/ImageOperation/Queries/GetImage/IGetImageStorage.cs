using Domain.UseCases.AdminOperatation.ProductOperation.Base;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Queries.GetImage;

public interface IGetImageStorage
{
    Task<ImageModel> GetImage(Guid id, CancellationToken cancellationToken);

    Task<bool> IsImageExists(Guid imageId, CancellationToken cancellationToken);
}
