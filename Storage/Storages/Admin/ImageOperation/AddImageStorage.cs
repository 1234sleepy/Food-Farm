using AutoMapper;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using Domain.UseCases.AdminOperatation.ImageOperation.Command.AddImage;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage.Storages.Admin.ImageOperaation;

public class AddImageStorage(DataContext dataContext, IMapper mapper) : IAddImageStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ImageModel> AddImage(Guid productId, string FileName, CancellationToken cancellationToken)
    {
        Image image = new Image
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

        return _mapper.Map<ImageModel>(image);
    }
}
