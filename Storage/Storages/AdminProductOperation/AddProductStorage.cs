
using AutoMapper;
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

        public async Task<ProductModel> AddProduct(string name, decimal price, CancellationToken cancellationToken)
        {
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price
            };

            await _dataContext.Products.AddAsync(product, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            var resProduct = await _dataContext.Products
            .AsNoTracking()
            .SingleAsync(p => p.Id == product.Id, cancellationToken);

            return _mapper.Map<ProductModel>(resProduct);
        }
    }
}
