using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.Label.Base;
using Domain.UseCases.Label.Query.GetAllUsedLabelByProductId;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Storages.LabelOperation;

public class GetAllUsedLabelByProductIdStorage(DataContext dataContext, IMapper mapper) : IGetAllUsedLabelByProductIdStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public async Task<List<LabelModel>> GetAllUsedLabels(Guid productId, CancellationToken cancellationToken)
    {
        var prodLabels = await _dataContext.ProductLabel.ToListAsync(cancellationToken);
        return await _dataContext.Labels
            .Where(label => prodLabels.Any(pl => pl.LabelId == label.Id && pl.ProductId == productId))
            .AsNoTracking()
            .ProjectTo<LabelModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
