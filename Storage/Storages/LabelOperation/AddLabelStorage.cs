using AutoMapper;
using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using Domain.UseCases.Label.Command.AddLabel;
using Storage.Entities;


namespace Storage.Storages.LabelOperation;

public class AddLabelStorage(DataContext dataContext, IMapper mapper) : IAddLabelStorage
{
    public async Task<LabelModel> AddLabel(string name, string color, CancellationToken cancellationToken)
    {
        Label label = new()
        {
            Name = name,
            Color = color
        };

        await dataContext.Labels.AddAsync(label, cancellationToken);
        await dataContext.SaveChangesAsync(cancellationToken);

        return mapper.Map<LabelModel>(label);
    }
}
