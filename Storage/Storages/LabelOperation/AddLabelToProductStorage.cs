using AutoMapper;
using Domain.UseCases.Label.Base;
using Domain.UseCases.Label.Command.AddLabelToProduct;
using Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Storages.LabelOperation;

public class AddLabelToProductStorage(DataContext dataContext, IMapper mapper) : IAddLabelToProductStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductLabelModel> AddLabelToProductAsync(Guid productId, Guid labelId, CancellationToken cancellationToken)
    {
        var productlabel = new ProductLabel
        {
            ProductId = productId,
            LabelId = labelId
        };

        await _dataContext.ProductLabel.AddAsync(productlabel, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProductLabelModel>(productlabel);

    }
}
