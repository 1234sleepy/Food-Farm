using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;
using Product.MicroService.Domain.UseCases.LabelOperation.Query.GetAllLables;

namespace Product.MicroService.Storage.Storages.LabelOperation;

public class GetAllLabelStorage(DataContext dataContext, IMapper mapper) : IGetAllLabelsStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public Task<List<LabelModel>> GetAllLabels(CancellationToken cancellationToken)
    {
        return _dataContext.Labels.AsNoTracking().ProjectTo<LabelModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}

