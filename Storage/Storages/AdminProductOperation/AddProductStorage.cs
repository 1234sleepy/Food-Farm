
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.AdminOrderOperation.Base;
using Domain.UseCases.AdminProductOperation.Base;
using Domain.UseCases.AdminProductOperation.Command.AddProduct;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;
using System;

namespace Storage.Storages.AdminProductOperation
{
    public class AddProductStorage(DataContext dataContext, IMapper mapper) : IAddProductStorage
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<ProductModel> AddProduct(string name, decimal price, int quantityLimit, string description, bool isVisible, decimal discountPrice, int quantitySold, List<Guid> imagesId, int totalCommentsQuantity, int totalRating, List<Guid> labelsId, CancellationToken cancellationToken)
        {

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


            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                Description = description,
                IsVisible = isVisible,
                CreatedAt = DateTimeOffset.UtcNow,
                DiscountPrice = discountPrice,
                Images = _mapper.Map<List<Image>>(Images),
                Labels = _mapper.Map<List<Label>>(Labels),
                QuantitySold = quantitySold,
                TotalCommentsQuantity = totalCommentsQuantity,
                TotalRating = totalRating,
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
    }
}
