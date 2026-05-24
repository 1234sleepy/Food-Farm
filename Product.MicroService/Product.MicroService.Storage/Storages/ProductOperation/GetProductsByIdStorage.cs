using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProductsById;

namespace Product.MicroService.Storage.Storages.ProductOperation;

public class GetProductsByIdStorage(DataContext dataContext, IMapper mapper) : IGetProductsByIdStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;

    IQueryable<ProductModel> IGetProductsByIdStorage.GetProductsById(GetProductsByIdQuery query)
    {
        var take = _dataContext.Products.AsNoTracking().Where(x => query.ids.Contains(x.Id.ToString())).Select(x => new ProductModel
        {
            Id = x.Id,
            Name = x.Name,
            Price = x.Price,
            QuantityLimit = x.QuantityLimit,
            QuantitySold = x.QuantitySold,
            Description = "",
        });



        return take;
    }
}
