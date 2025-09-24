using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.Label.Base;
using Domain.UseCases.Label.Query.GetAllLabels;
using Microsoft.EntityFrameworkCore;

namespace Storage.Storages.LabelOperation;

public class GetAllLabelStorage(DataContext dataContext, IMapper mapper) : IGetAllLabelsStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public Task<List<LabelModel>> GetAllLabels(CancellationToken cancellationToken)
    {
        return _dataContext.Labels.AsNoTracking().ProjectTo<LabelModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}

