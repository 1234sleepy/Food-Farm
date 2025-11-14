using AutoMapper;
using Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabelToProduct;
using Product.MicroService.Storage.Entities;

namespace Product.MicroService.Storage.Storages.LabelOperation;

public class AddLabelToProductStorage(DataContext dataContext, IMapper mapper) : IAddLabelToProductStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task AddLabelToProductAsync(Guid productId, Guid labelId, CancellationToken cancellationToken)
    {
        var productlabel = new ProductLabel
        {
            ProductId = productId,
            LabelId = labelId
        };

        await _dataContext.ProductLabel.AddAsync(productlabel, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

    }
}
