using AutoMapper;
using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabelToProduct;

namespace Product.MicroService.Storage.Storages.LabelOperation;

public class AddLabelToProductStorage(DataContext dataContext, IMapper mapper) : IAddLabelToProductStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task AddLabelToProduct(Guid productId, Guid labelId, CancellationToken cancellationToken)
    {
        var productlabel = new ProductLabelEntity
        {
            ProductId = productId,
            LabelId = labelId
        };

        await _dataContext.ProductLabel.AddAsync(productlabel, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

    }
}
