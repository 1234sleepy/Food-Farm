using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;
using Product.MicroService.Domain.UseCases.LabelOperation.Query.GetAllUsedLabelByProductId;

namespace Product.MicroService.Storage.Storages.LabelOperation;

public class GetAllUsedLabelByProductIdStorage(DataContext dataContext, IMapper mapper) : IGetAllUsedLabelByProductIdStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public async Task<List<LabelModel>> GetAllUsedLabels(Guid productId, CancellationToken cancellationToken)
    {
        return await _dataContext.ProductLabel
            .AsNoTracking()
            .Where(label => label.ProductId == productId)
            .Include(pl => pl.Label)
            .Select(pl => pl.Label)
            .ProjectTo<LabelModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
