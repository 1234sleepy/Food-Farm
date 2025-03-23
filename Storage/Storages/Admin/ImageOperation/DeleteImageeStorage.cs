using Domain.UseCases.AdminOperatation.ImageOperation.Command.DeleteImage;
using Microsoft.EntityFrameworkCore;

namespace Storage.Storages.Admin.ImageOperaation;

public class DeleteImageeStorage(DataContext dataContext) : IDeleteImageStorage
{
    private readonly DataContext _dataContext = dataContext;
    public async Task DeleteImage(Guid imageId, CancellationToken cancellationToken)
    {
        var image = await _dataContext.Images.FirstAsync(x => x.Id == imageId, cancellationToken);
        var productId = image.ProductId;

        _dataContext.Images.Remove(image);

        var newMainImage = await _dataContext.Images.FirstOrDefaultAsync(x => x.ProductId == productId && x.Id != image.Id);

        if (newMainImage is not null)
             newMainImage.IsMain = true;

        await _dataContext.SaveChangesAsync(cancellationToken);

    }

    public Task<bool> IsImageExists(Guid imageId, CancellationToken cancellationToken)
    {
        return _dataContext.Images.AnyAsync(x => x.Id == imageId, cancellationToken);
    }
}
