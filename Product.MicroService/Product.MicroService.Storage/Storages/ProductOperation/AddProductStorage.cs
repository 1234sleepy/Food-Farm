using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;
using Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabelToProduct;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;
using Product.MicroService.Storage.Entities;
using Product.MicroService.Storage.Storages.LabelOperation;
using System.Reflection.Emit;

namespace Product.MicroService.Storage.Storages.ProductOperation;

public class AddProductStorage(DataContext dataContext, IMapper mapper, IAddLabelToProductStorage addLabelToProductStorage) : IAddProductStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    private readonly IAddLabelToProductStorage _addLabelToProductStorage = addLabelToProductStorage;

    public async Task<ProductModel> AddProduct(string name, decimal price, int quantityLimit, string description, decimal discountPrice, List<LabelModel> labels, CancellationToken cancellationToken)
    {
        var product = await AddProduct(name, price, quantityLimit, description, discountPrice, cancellationToken);

        foreach (var lab in labels)
        {
            await _addLabelToProductStorage.AddLabelToProduct(product.Id, lab.Id, cancellationToken);
        }

        return product;
    }

    public async Task<ProductModel> AddProduct(string name, decimal price, int quantityLimit, string description, decimal discountPrice, CancellationToken cancellationToken)
    {
        ProductE product = new ProductE()
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



        return resProduct;
    }

    public async Task<ProductModel> AddProductSimple(string name, decimal price, int quantityLimit, string description, decimal discountPrice, CancellationToken cancellationToken)
    {
        ProductE product = new ProductE()
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

        return _mapper.Map<ProductModel>(product);
    }
}
