using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using Domain.UseCases.AdminOperatation.ProductOperation.Command.UpdateProduct;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage.Storages.Admin.ProductOperation;

public class UpdateProductStorage(DataContext dataContext, IMapper mapper) : IUpdateProductStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductModel> UpdateProduct(Guid id, string name, decimal price, int quantityLimit, string description, bool isVisible, decimal discountPrice, CancellationToken cancellationToken)
    {
        Product nwProduct = await _dataContext.Products.FirstAsync(p => p.Id == id, cancellationToken);

        nwProduct.Name = name;
        nwProduct.Price = price;
        nwProduct.Description = description;
        nwProduct.IsVisible = isVisible;
        nwProduct.QuantityLimit = quantityLimit;
        nwProduct.DiscountPrice = discountPrice;


        _dataContext.Products.Update(nwProduct);
        await _dataContext.SaveChangesAsync(cancellationToken);

        var resProd = await _dataContext.Products
    .AsNoTracking()
    .ProjectTo<ProductModel>(_mapper.ConfigurationProvider)
    .SingleAsync(p => p.Id == id, cancellationToken);

        return resProd;
    }

}
