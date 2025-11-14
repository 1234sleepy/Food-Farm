using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.MicroService.Domain.UseCases.ImageOperation.Queries.GetImage;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Storage.Storages.ImageOperation;

public class GetImageStorage(DataContext dataContext, IMapper mapper) : IGetImageStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public async Task<ImageModel> GetImage(Guid id, CancellationToken cancellationToken)
    {
        var image = await _dataContext.Images.AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken);

        return _mapper.Map<ImageModel>(image);
    }

    public Task<bool> IsImageExists(Guid imageId, CancellationToken cancellationToken)
    {
        return _dataContext.Images.AnyAsync(x => x.Id == imageId, cancellationToken);
    }
}
