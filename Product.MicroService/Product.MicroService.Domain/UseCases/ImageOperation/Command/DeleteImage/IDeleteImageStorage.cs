namespace Product.MicroService.Domain.UseCases.ImageOperation.Command.DeleteImage;

public interface IDeleteImageStorage
{
    Task DeleteImage(Guid imageId, CancellationToken cancellationToken);

    Task<bool> IsImageExists(Guid imageId, CancellationToken cancellationToken);
}
