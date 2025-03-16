using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Command;

public interface IAddImageStorage
{
    public Task<ImageModel> AddImage(Guid productId, string FileName, CancellationToken cancellationToken);
}
