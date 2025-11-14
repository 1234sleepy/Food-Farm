using AutoMapper;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;
using Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabel;
using Product.MicroService.Storage.Entities;

namespace Product.MicroService.Storage.Storages.LabelOperation;
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