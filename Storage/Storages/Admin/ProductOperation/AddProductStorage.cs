
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Command.AddProduct;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage.Storages.Admin.AdminProductOperation
{
    public class AddProductStorage(DataContext dataContext, IMapper mapper) : IAddProductStorage
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<ProductModel> AddProduct(string name, decimal price, int quantityLimit, string description, decimal discountPrice, CancellationToken cancellationToken)
        {



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

            return resProduct;
        }
    }
}
