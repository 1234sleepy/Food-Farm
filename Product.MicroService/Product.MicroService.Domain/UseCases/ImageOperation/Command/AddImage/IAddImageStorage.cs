using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Command.AddImage;

public interface IAddImageStorage
{
    public Task<ImageModel> AddImage(Guid productId, string FileName, CancellationToken cancellationToken);
}
