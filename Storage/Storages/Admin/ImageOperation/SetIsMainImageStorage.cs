using AutoMapper;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using Domain.UseCases.AdminOperatation.ImageOperation.Command.SetIsMainImage;
using Microsoft.EntityFrameworkCore;

namespace Storage.Storages.Admin.ImageOperation
{
    public class SetIsMainImageStorage(DataContext dataContext, IMapper mapper) : ISetIsMainImageStorage
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;
        public async Task<ImageModel> SetIsMainImage(Guid imageId, CancellationToken cancellationToken)
        {
            var image = await _dataContext.Images.FirstAsync(x => x.Id == imageId, cancellationToken);
            var productId = image.ProductId;

            var previousMainImage = await _dataContext.Images.FirstAsync(x => x.IsMain && x.ProductId == productId, cancellationToken);
            previousMainImage.IsMain = false;

            image.IsMain = true;

            await _dataContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ImageModel>(image);
        }

        public Task<bool> IsImageExists(Guid imageId, CancellationToken cancellationToken)
        {
            return _dataContext.Images.AnyAsync(x => x.Id == imageId, cancellationToken);
        }
    }



}
