namespace Domain.UseCases.AdminOperatation.ImageOperation.Command.DeleteImage;

public interface IDeleteImageStorage
{
    Task DeleteImage(Guid imageId, CancellationToken cancellationToken);

    Task<bool> IsImageExists(Guid imageId, CancellationToken cancellationToken);
}
