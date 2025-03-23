using AutoMapper;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using Domain.UseCases.AdminOperatation.ImageOperation.Queries.GetImage;
using Microsoft.EntityFrameworkCore;

namespace Storage.Storages.Admin.ImageOperation;

public class GetImageStorage(DataContext dataContext, IMapper mapper) : IGetImageStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public async Task<ImageModel> GetImage(Guid productId, CancellationToken cancellationToken)
    {
        var image = await _dataContext.Images.AsNoTracking().FirstAsync(x => x.ProductId == productId, cancellationToken);

        return _mapper.Map<ImageModel>(image);
    }

    public Task<bool> IsImageExists(Guid imageId, CancellationToken cancellationToken)
    {
        return _dataContext.Images.AnyAsync(x => x.Id == imageId, cancellationToken);
    }
}
