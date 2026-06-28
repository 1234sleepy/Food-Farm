using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

    public async Task<Guid> GetId(string name, CancellationToken cancellationToken)
    {
        return await dataContext.Labels.Where(x => x.Name == name).Select(x => x.Id).FirstAsync(cancellationToken);
    }

    public async Task<bool> IsExist(string name, string color, CancellationToken cancellationToken)
    {
        return await dataContext.Labels.AnyAsync(x => x.Name == name, cancellationToken);
    }
}