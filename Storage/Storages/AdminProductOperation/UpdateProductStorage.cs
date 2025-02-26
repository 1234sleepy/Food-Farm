using AutoMapper;
using Domain.UseCases.AdminProductOperation.Base;
using Domain.UseCases.AdminProductOperation.Command.UpdateProduct;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage.Storages.AdminProductOperation;

public class UpdateProductStorage(DataContext dataContext, IMapper mapper) : IUpdateProductStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductModel> UpdateProduct(Guid id, string name, decimal price, int quantityLimit, string description, bool isVisible, decimal discountPrice, int quantitySold, List<ImageModel> Images, int totalCommentsQuantity, int totalRating, List<LabelModel> Labels, CancellationToken cancellationToken)
    {
        Product nwProduct = await _dataContext.Products.FirstAsync(p => p.Id == id, cancellationToken);

        nwProduct.Name = name;
        nwProduct.Price = price;
        nwProduct.QuantityLimit = quantityLimit;
        nwProduct.Description = description;
        nwProduct.IsVisible = isVisible;
        nwProduct.DiscountPrice = discountPrice;
        nwProduct.QuantitySold = quantitySold;
        nwProduct.Images = _mapper.Map<List<Image>>(Images);
        nwProduct.TotalCommentsQuantity = totalCommentsQuantity;
        nwProduct.TotalRating = totalRating;
        nwProduct.Labels = _mapper.Map<List<Label>>(Labels);

        _dataContext.Products.Update(nwProduct);
        await _dataContext.SaveChangesAsync(cancellationToken);

        var resProd = await _dataContext.Products
   .AsNoTracking()
   .SingleAsync(p => p.Id == id, cancellationToken);

        return _mapper.Map<ProductModel>(resProd);
    }
}
