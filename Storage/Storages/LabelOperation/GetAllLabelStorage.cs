using AutoMapper;
using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using Domain.UseCases.Label.Query.GetAllLabels;

namespace Storage.Storages.LabelOperation;

public class GetAllLabelStorage(DataContext dataContext, IMapper mapper) : IGetAllLabelsStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public Task<List<LabelModel>> GetAllLabels(CancellationToken cancellationToken)
    {
        var labels = _dataContext.Labels.ToList();
        return Task.FromResult(_mapper.Map<List<LabelModel>>(labels));
    }
}

