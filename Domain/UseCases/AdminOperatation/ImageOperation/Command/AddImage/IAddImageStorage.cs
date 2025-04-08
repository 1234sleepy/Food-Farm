using Domain.UseCases.AdminOperatation.ProductOperation.Base;

namespace Domain.UseCases.AdminOperatation.ImageOperation.Command.AddImage;

public interface IAddImageStorage
{
    public Task<ImageModel> AddImage(Guid productId, string FileName, CancellationToken cancellationToken);
}
