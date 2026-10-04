using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.ImageOperation.Command.AddImage;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;


namespace Product.MicroService.Storage.Storages.ImageOperation;

public class AddImageStorage(DataContext dataContext, IMapper mapper) : IAddImageStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ImageEntity> AddImage(Guid productId, string FileName, CancellationToken cancellationToken)
    {
        ImageEntity image = new ImageEntity
        {
            Id = Guid.NewGuid(),
            ProductId = productId,
            Name = FileName,
            CreatedAt = DateTimeOffset.UtcNow,
            IsMain = false,

        };

        if (!await _dataContext.Images.Where(x => x.ProductId == productId).AnyAsync(cancellationToken))
        {
            image.IsMain = true;
        }

        await _dataContext.Images.AddAsync(image, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return image;
    }
}
