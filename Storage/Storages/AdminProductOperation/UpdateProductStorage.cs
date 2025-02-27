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

    public async Task<ProductModel> UpdateProduct(Guid id, string name, decimal price, int quantityLimit, string description, bool isVisible, decimal discountPrice, int quantitySold, List<Guid> imagesId, int totalCommentsQuantity, int totalRating, List<Guid> labelsId, CancellationToken cancellationToken)
    {
        Product nwProduct = await _dataContext.Products.FirstAsync(p => p.Id == id, cancellationToken);

        List<Image> Images = new List<Image>();
        List<Label> Labels = new List<Label>();

        if (imagesId.Count > 0)
        {
            foreach (var imageid in imagesId)
            {
                Image? image = await _dataContext.Images.FirstOrDefaultAsync(p => p.Id == imageid, cancellationToken);
                if (image != null)
                {
                    Images.Add(image);
                }
            }
        }

        if (Labels.Count > 0)
        {
            foreach (var labelId in labelsId)
            {
                Label? label = await _dataContext.Labels.FirstOrDefaultAsync(p => p.Id == labelId, cancellationToken);
                if (label != null)
                {
                    Labels.Add(label);
                }
            }
        }



        nwProduct.Name = name;
        nwProduct.Price = price;
        nwProduct.Description = description;
        nwProduct.IsVisible = isVisible;
        nwProduct.QuantityLimit = quantityLimit;
        nwProduct.DiscountPrice = discountPrice;
        nwProduct.QuantitySold = quantitySold;
        nwProduct.TotalCommentsQuantity = totalCommentsQuantity;
        nwProduct.TotalRating = totalRating;
        nwProduct.Images = _mapper.Map<List<Image>>(Images);
        nwProduct.Labels = _mapper.Map<List<Label>>(Labels);

        _dataContext.Products.Update(nwProduct);
        await _dataContext.SaveChangesAsync(cancellationToken);

        var resProd = await _dataContext.Products
   .AsNoTracking()
   .SingleAsync(p => p.Id == id, cancellationToken);

        return _mapper.Map<ProductModel>(resProd);
    }
}
