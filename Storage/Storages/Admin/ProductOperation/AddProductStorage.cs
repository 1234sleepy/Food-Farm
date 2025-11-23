using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using Domain.UseCases.AdminOperatation.ProductOperation.Command.AddProduct;
using Domain.UseCases.Label.Base;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;
using Storage.Storages.LabelOperation;

namespace Storage.Storages.Admin.ProductOperation;

public class AddProductStorage(DataContext dataContext, IMapper mapper) : IAddProductStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductModel> AddProduct(string name, decimal price, int quantityLimit, string description, decimal discountPrice, List<LabelModel>labels, CancellationToken cancellationToken)
    {

        AddLabelToProductStorage addLabelToProductStorage = new AddLabelToProductStorage(_dataContext, _mapper);

        Product product = new Product()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Price = price,
            Description = description,
            IsVisible = true,
            CreatedAt = DateTimeOffset.UtcNow,
            DiscountPrice = discountPrice,
            QuantitySold = 0,
            TotalCommentsQuantity = 0,
            TotalRating = 0,
            QuantityLimit = quantityLimit
        };

        await _dataContext.Products.AddAsync(product, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        var resProduct = await _dataContext.Products
        .AsNoTracking()
        .ProjectTo<ProductModel>(_mapper.ConfigurationProvider)
        .SingleAsync(p => p.Id == product.Id, cancellationToken);

        foreach (var lab in labels)
        {
            await addLabelToProductStorage.AddLabelToProductAsync(product.Id, lab.Id, cancellationToken);
        }

        return resProduct;
    }
}
